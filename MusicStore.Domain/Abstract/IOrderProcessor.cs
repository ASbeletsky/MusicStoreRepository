using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Abstract
{
    interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, OrderDetails orderDetails);
    }
}
