//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UrunTakipSistemiMvc5.Models.Entitiy
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_urunler()
        {
            this.tbl_satislar = new HashSet<tbl_satislar>();
        }
    
        public int urun_id { get; set; }
        public string urun_ad { get; set; }
        public string urun_marka { get; set; }
        public Nullable<short> urun_stok { get; set; }
        public Nullable<decimal> alis_fiyat { get; set; }
        public Nullable<decimal> satis_fiyat { get; set; }
        public Nullable<int> urun_kategori { get; set; }
        public Nullable<bool> urun_durum { get; set; }
    
        public virtual tbl_kategoriler tbl_kategoriler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_satislar> tbl_satislar { get; set; }
    }
}
