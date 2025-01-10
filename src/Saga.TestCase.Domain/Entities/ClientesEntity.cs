using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saga.TestCase.Domain.Entities
{
    public class ClientesEntity
    {

        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string RFC { get; set; }
        public string CuentaBancariaId { get; set; }
    }
}
