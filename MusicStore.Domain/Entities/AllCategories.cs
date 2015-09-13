using System.Collections.Generic;

namespace MusicStore.Domain.Entities
{
    public class AllCategories
    {
            public IEnumerable<productcategory> Categories { get; set; }
            public IEnumerable<genericcategory> GenericCategories { get; set; }
    }
}
