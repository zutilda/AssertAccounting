//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Adress
    {
        public int ID { get; set; }
        public string ConnectionPoint { get; set; }
        public string Location { get; set; }
        public int District { get; set; }
        public string GeoPosition { get; set; }
        public string Discriotion { get; set; }
    
        public virtual District District1 { get; set; }
        public virtual InstallDevice InstallDevice { get; set; }
    }
}
