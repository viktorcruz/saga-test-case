namespace Saga.TestCase.Domain.Entities
{
    public class VentasEntity
    {
        public string Id { get; set; }
        public string Folio { get; set; }
        public int Cantidad { get; set; }
        public int CodigoTasaIva { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IVA { get; set; }
        public decimal ImporteTotal { get; set; }
        public DateTime FechaVenta { get; set; }
        public bool Activo { get; set; }
    }
}
