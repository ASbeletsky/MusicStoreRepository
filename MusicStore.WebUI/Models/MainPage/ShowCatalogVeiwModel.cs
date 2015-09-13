using System.Collections.Generic;

namespace MusicStore.WebUI.Models.MainPage
{
    public class Tab
    {
        public Tab()
        {
            this.SubTabs = new List<SubTab>();
        }

        public string GenericCategoryName { get; set; }
        public List<SubTab> SubTabs { get; set; } 
    }

    public class SubTab
    {
        public SubTab()
        {
            ListOfProducers = new List<string>();
        }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string ImagePath { get; set; }
        public List<string> ListOfProducers { get; set; }
    }
    public class ShowCatalogViewModel
    {
        public ShowCatalogViewModel()
        {
            this.Tabs = new List<Tab>();
        }
        public List<Tab> Tabs { get; set; }       
    }
}