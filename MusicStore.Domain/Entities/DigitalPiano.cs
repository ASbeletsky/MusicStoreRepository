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
    
    public partial class DigitalPiano : Keyboard
    {
        public DigitalPiano()
        {
            this.Pedals = new DigitalPianoPedals();
            this.OtherFunctions = new DigitalPianoOtherFunctions();
        }
    
        public Nullable<int> CompositionQuantity { get; set; }
    
        public DigitalPianoPedals Pedals { get; set; }
        public DigitalPianoOtherFunctions OtherFunctions { get; set; }
    }
}