//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pjdgatovka1.model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tovar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Opisanie { get; set; }
        public byte[] Image { get; set; }
        public Nullable<int> Id_tip { get; set; }
    }
}