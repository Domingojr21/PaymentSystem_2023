namespace SistemadeFacturacion_2023.Models
{
    public class Productos
    {
        public int IDProductos { get; set; }
        public string Item { get; set; }
        public string Descripcion { get; set; }
        public int CantidadEnExistencia { get; set; }
        public double Costo { get; set; }   
        public double PreciodeVenta { get; set; }
        public double Impuesto { get; set; }
        public int EstatusProducto { get; set; }  
        public string BarCode { get; set; } 
        public string Imagen { get; set; }
        public string Ruta { get; set; }
        public int IdFatura { get; set; }

    }
}
