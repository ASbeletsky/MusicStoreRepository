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
    
    public partial class ElectroAndBassGuitar : Guitar
    {
        public ElectroAndBassGuitar()
        {
            this.MaterialEnB = new ElectroAndBassGuitarMaterial();
            this.ConstructionEnB = new ElectroAndBassGuitarConstruction();
            this.ElectronicEnB = new ElectroAndBassGuitarElectonic();
        }
    
        public string Tremolo { get; set; }
    
        public ElectroAndBassGuitarMaterial MaterialEnB { get; set; }
        public ElectroAndBassGuitarConstruction ConstructionEnB { get; set; }
        public ElectroAndBassGuitarElectonic ElectronicEnB { get; set; }
    }
}
