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
    
    public partial class ApplicationCRM
    {
        public int ID { get; set; }
        public System.DateTime DateCreate { get; set; }
        public string PersonalAccountUser { get; set; }
        public int Service { get; set; }
        public int KindService { get; set; }
        public int TypeService { get; set; }
        public int StatusApplication { get; set; }
        public int TypeDevice { get; set; }
        public string DescriptionProblem { get; set; }
        public System.DateTime ClisingDate { get; set; }
        public int TypeProblem { get; set; }
    
        public virtual KindServise KindServise { get; set; }
        public virtual Service Service1 { get; set; }
        public virtual Status Status { get; set; }
        public virtual TypeDevice TypeDevice1 { get; set; }
        public virtual TypeOfProblem TypeOfProblem { get; set; }
        public virtual TypeService TypeService1 { get; set; }
    }
}
