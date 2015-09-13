using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Domain.Entities
{
    //Запись о товар в корзине
    public class ProductLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
    public class Cart
    {
        //Коллекция товаров 
        private List<ProductLine> LineCollection = new List<ProductLine>();
        //Добавление в корзину
        public void AddLine(Product product, int quantity)
        {
            //Проверка на наличие его в корзине
            ProductLine line = LineCollection.Where(i => i.Product.Id == product.Id)
                                             .FirstOrDefault();
            //Если нет - добавляем
            if (line == null)
            {
                LineCollection.Add(new ProductLine
                    {
                        Product = product,
                        Quantity = quantity
                    });
            }
            //Есть - увевиличаем коллчество
            else
                line.Quantity += quantity;                                                       
        }

        //Удаление с корзины
        public void RemoveLine(Product product)
        {
            LineCollection.RemoveAll(i => i.Product.Id == product.Id);
        }
        //Вычисление полной суммы
        public Nullable<decimal> ComputeTotalSum()
        {
            return LineCollection.Sum(i => i.Product.General.Price * i.Quantity);
        }
        //Очистить корзину
        public void Clear()
        {
            LineCollection.Clear();
        }
        //Свойство для просмотра содержимого
        public IEnumerable<ProductLine> Lines
        {
            get { return LineCollection; }
        }
    }
}
