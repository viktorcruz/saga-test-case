using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saga.TestCase.Domain.Entities
{
    public class OpcionesEntity
    {
        public int Id { get; set; }
        public string AccesoDatos { get; set; }
        public int CantidadRespaldos { get; set; }
        public string RutaRespaldos { get; set; }
    }
}
