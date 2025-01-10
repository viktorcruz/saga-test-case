using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saga.TestCase.Domain.Entities
{
    public class ProductosEntity
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioPublico { get; set; }
        public decimal PrecioEspecial { get; set; }
        public bool Activo { get; set; }
    }
}
