using _2FluentValidation.Models;
using FluentValidation;

namespace _2FluentValidation.FluentValidators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz";
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("Email alanı doğru formatta olmalıdır.");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18, 60).WithMessage("Age alanı 18 ile 60 arasında olmalıdır.");

            //Must Metodu ile birlikte custom validatorlar yazılabilir.
            //Custom metodların client tarafında karşılığı yoktur. Server side taraflı hata fırlatmaktadır.
            RuleFor(x => x.BirthDay).NotEmpty().WithMessage(NotEmptyMessage).Must(x =>
            {
                return DateTime.Now.AddYears(-18) >= x;
            }).WithMessage("Yaşınız 18 yaşından büyük olmalıdır");

            //Enum validation
            RuleFor(_ => _.Gender).IsInEnum().WithMessage("{PropertyName} alanı Erkek için=1,Bayan için=2 olmalıdır.");

            //1-n ilişkili yapıda validasyon işlemi.
            RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());
        }
    }
}
