//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyect.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class articulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public articulo()
        {
            this.usuario_articulo = new HashSet<usuario_articulo>();
        }
    
        public int idarticulo { get; set; }
        public string nombre_articulo { get; set; }
        public string texto_articulo { get; set; }
        public bool estado { get; set; }
        public int idtitulo { get; set; }
    
        public virtual titulo titulo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario_articulo> usuario_articulo { get; set; }
    }
}