using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saga.TestCase.Application.Opciones.Commands.Dto
{
    public class OpcionesRequestDTO
    {
        public int Id { get; set; }
        public string AccesoDatos { get; set; }
        public int CantidadRespaldos { get; set; }
        public string RutaRespaldos { get; set; }
    }
}
