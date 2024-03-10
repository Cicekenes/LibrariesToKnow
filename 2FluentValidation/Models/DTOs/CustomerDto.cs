namespace _2FluentValidation.Models.DTOs
{
    public class CustomerDto
    {
        //public int Id { get; set; }
        //public string? Name { get; set; }
        //public string? Email { get; set; }
        //public int Age { get; set; }
        public int Id { get; set; }
        public string? Isim { get; set; }
        public string? Posta { get; set; }
        public int Yas { get; set; }
        public string FullName { get; set; }

        //Flattening
        //public string CreditCardNumber { get; set; } //ClassName + PropertyName
        //public DateTime CreditCardValidDate { get; set; } //ClassName + PropertyName
        public string Number { get; set; } //ClassName + PropertyName
        public DateTime ValidDate { get; set; } //ClassName + PropertyName
    }
}
