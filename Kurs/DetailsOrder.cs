//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kurs
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetailsOrder
    {
        public int Id_DetOrder { get; set; }
        public Nullable<int> Id_Order { get; set; }
        public Nullable<int> Id_Prod { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
