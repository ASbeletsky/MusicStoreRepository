//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicStore.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class productcategory
    {
        public productcategory()
        {
            this.product = new HashSet<Product>();
        }
    
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public int GenericCategory_Id { get; set; }
    
        public virtual ICollection<Product> product { get; set; }
        public virtual genericcategory genericcategory { get; set; }
    }
}
