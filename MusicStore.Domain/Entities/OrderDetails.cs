using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Domain.Entities
{
    public class OrderDetails
    {
        public OrderDetails()
        {
            this.DelivaryCost = 35;            
        }
        public int Id { get; set; }
        [Required(ErrorMessage="Укажите ваше имя")]       
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите вашу фамилию")]
        public string LastName { get; set; } 
        [Required(ErrorMessage = "Укажите ваш телефон")]   
        public string Phone { get; set; }
        [Required(ErrorMessage = "Укажите ваш электронный адрес")]   
        public string Email { get; set; }
        [Required(ErrorMessage = "Укажите ваш адрес")]   
        public AddressVM Address { get; set; }
        public decimal DelivaryCost { get; set; }
        public PaymentVM Payment { get; set; }
        public  string Note{ get; set; }
        public decimal TotalSum { get; set; }
        public IEnumerable<ProductLine> Products { get; set; }
        
        public class AddressVM
        {
            [Required(ErrorMessage = "Укажите город")]
            [Display(Name="Город")]
            public string City { get; set; }
            [Required(ErrorMessage = "Укажите улицу")]
            [Display(Name = "Улица")]
            public string Street { get; set; }
            [Required(ErrorMessage = "Укажите дом")]
            [Display(Name = "Дом")]
            public string House { get; set; }
            [Display(Name = "Кв.")]
            public int Apartment { get; set; }
        }
        public class PaymentVM 
        {
            public PaymentVM()
            {
                this.PaymentType = new PaymentType();
            }
            public PaymentType PaymentType { get; set; }
            public PaymentType[] GetTypes()
            {
                EFDbContext context = new EFDbContext();
                PaymentType[] types = context.PaymentTypes.Select(x => x).ToArray();
                return types;               
            }
        }
    }
}
