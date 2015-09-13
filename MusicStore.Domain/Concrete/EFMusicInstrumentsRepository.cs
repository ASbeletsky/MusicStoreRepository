using System;
using System.Collections.Generic;
using System.Linq;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Abstract;


namespace MusicStore.Domain.Concrete
{
        //Хранилище данных
    public class EFMusicInstrumentsRepository : IMusicInstrumentRepository
    {        
        private EFDbContext context = new EFDbContext(); 
        public IEnumerable<Product> musicInstruments
        {
            get { return context.Products;}
        }
        
        public IEnumerable<Order> orders
        {
            get { return context.Orders; }               
        }
        public IEnumerable<city> cities
        {
            get { return context.city; }
        }

        public IEnumerable<slides> slides
        {
            get { return context.slides;} 
        }

        public IEnumerable<UserPhone> userPhones 
        {
            get { return context.UserPhones; }
        }
        public IEnumerable<Address> Addresses 
        {
            get { return context.Addresess; }
        }

        public AllCategories categories 
        {
            get 
            {
                return new AllCategories
                {
                    Categories = context.productcategory.ToList(),
                    GenericCategories = context.genericcategory
                }; 
            }
        }

        public void AddOrder(OrderDetails orderDetails)
        {/*
            List<Product> products = new List<Product>();
            //products.Add(context.Products.Find(3));
            foreach(var productLine in orderDetails.Products)
            {
                for (int i = 1; i <= productLine.Quantity; i++)
                    products.Add(context.Products.First(x => x.Id == productLine.Product.Id));
            }
            
            
            using(context)
            {
                Order newOrder = new Order()
                {
                    DateTime = DateTime.Now,
                    TotalSum = orderDetails.TotalSum,
                    product = products
                };
              
                Customer customer = new Customer()
                {
                    Name = orderDetails.Name,
                    LastName = orderDetails.LastName,
                    Mail = orderDetails.Email,
                    Phone = orderDetails.Phone
                };

                Delivary dalivary = new Delivary()
                {
                    Cost = orderDetails.DelivaryCost,
                    Address = new Address()
                    {
                        City = orderDetails.Address.City,
                        Street = orderDetails.Address.Street,
                        House = orderDetails.Address.House,
                        Apartment = orderDetails.Address.Apartment

                    }
                };

                newOrder.customer = customer;
                newOrder.PaymentTypes_Id = orderDetails.Payment.PaymentType.Id;
                dalivary.Order_Id = newOrder.Id;
                
                
                context.Orders.Add(newOrder);               
                context.SaveChanges();
                 */                          
            
        }


    }
}
