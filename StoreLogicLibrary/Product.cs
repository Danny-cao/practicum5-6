//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StorageLogicLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Stock { get; set; }
        public int StoreId { get; set; }
    
        public virtual Store Store { get; set; }
    }
}
