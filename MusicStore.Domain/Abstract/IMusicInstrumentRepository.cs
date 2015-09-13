using System.Collections.Generic;
using MusicStore.Domain.Entities;

//Абстрактное хранилище данных
namespace MusicStore.Domain.Abstract
{
    //Позволяет получать последовательность инструментов 
    public interface IMusicInstrumentRepository
    {
        IEnumerable<Product> musicInstruments { get; }
        AllCategories categories { get; }
        IEnumerable<Order> orders { get; }
        IEnumerable<city> cities { get; }
        IEnumerable<slides> slides { get; }
        IEnumerable<UserPhone> userPhones { get; }
        IEnumerable<Address> Addresses { get; }
        void AddOrder(OrderDetails OrderDetails);
        
    }
}
