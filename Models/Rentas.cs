//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentaDePeliculas.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rentas
    {
        public int IdRenta { get; set; }
        public int IdCliente { get; set; }
        public int IdPeliculas { get; set; }
        public System.DateTime Fecha { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Peliculas Peliculas { get; set; }
    }
}
