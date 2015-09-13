using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStore.Domain.Entities;

namespace MusicStore.WebUI.Models.ProductDetail
{
    public class DetailProductViewModel
    {
        public DetailProductViewModel()
        {
            this.Characteristics = new List<Characteristic>();
        }
        public string ImagePath {get;set;}
        public decimal DelivaryCost { get; set; }
        public List<Characteristic> Characteristics { get; set; }
        public string VideoPath { get; set; }
    }
    public class Field
    {
        public string Messege { get; set; }
        public dynamic Value { get; set; }
    }

    public class Characteristic
    {
        public Characteristic() { }
        public Characteristic(string title)
        {
            Title = title;
            Properties = new Dictionary<string, Field>();
        }
        public string Title;
        public Dictionary<string, Field> Properties { get; set; }
    }




}