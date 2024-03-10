namespace _2FluentValidation.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public DateTime? BirthDay { get; set; }
        //Customer.Address[1].Id,index olarak kullanabilmek için IList yazıyoruz.
        public IList<Address> Addresses { get; set; }
        public Gender Gender { get; set; }

        //Flattening
        public CreditCard CreditCard { get; set; }

        //Metod adı Get ile başlarsa ise otomatik mapping yapıyor.
        public string GetFullName()
        {
            return $"{Name}-{Email}-{Age}";
        }
    }
}
