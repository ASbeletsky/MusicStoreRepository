using System.Collections.Generic;
using MusicStore.Domain.Entities;

namespace MusicStore.WebUI.Models.MusicInstruments
{
    public class MusicInstrumentsListViewModel
    {
        public IEnumerable<Product> Instruments { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public int CurrentCategory { get; set; }
    }
}
