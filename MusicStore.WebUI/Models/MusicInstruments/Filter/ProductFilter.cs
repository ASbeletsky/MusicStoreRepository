using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStore.Domain.Entities;

namespace MusicStore.WebUI.Models.MusicInstruments.Filter
{
    public class ProductFilter
    {
        public ProductFilter ()
	{
            this.producers = new List<ProducerVM>();
            this.colors = new List<ColorVM>();
	}
        public int category { get; set; }
        public List<ProducerVM> producers { get; set; }
        public List<ColorVM> colors { get; set; }
        public decimal maxPrice { get; set; }
        public decimal minPrice { get; set; }

    }
   
   public class ProducerVM : Producer
   {
       public bool IsChecked { get; set; }
   }
   public class ColorVM : Color
   {
       public bool IsChecked { get; set; }
   }
}
    