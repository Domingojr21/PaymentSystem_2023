namespace SistemadeFacturacion_2023.Models
{

    public class Factura
    {
        public int IDFactura { get; set; }
        public int Codigo { get; set; }
        public string Fecha { get; set; }
        public string Articulo { get; set; }
        public  double Cantidad { get; set; }
        public double PrecioDeVenta { get; set; }
        public double Impuesto { get; set; }
        public double MontoPorLinea { get; set; }
        public bool IsDeleted { get; set; } 
        public int IdCliente { get; set; }
    }
}
