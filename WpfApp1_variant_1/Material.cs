//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1_variant_1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            this.Providers = new HashSet<Provider>();
        }
    
        public int id { get; set; }
        public string Name { get; set; }
        public string Type_material { get; set; }
        public byte[] Image { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<int> MinCount { get; set; }
        public Nullable<int> CountInPack { get; set; }
        public string Unit { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Provider> Providers { get; set; }
        public string AllProviders => string.Join(", ", Providers.Select(p => p.Name).Where(n => !string.IsNullOrEmpty(n)).DefaultIfEmpty("Не указано"));
    }
}
