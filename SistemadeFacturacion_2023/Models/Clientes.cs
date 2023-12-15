namespace SistemadeFacturacion_2023.Models
{
    public class Clientes
    {
        public int IDcliente { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Sector { get; set; }
        public string? Ciudad { get; set; }
        public string? Pais { get; set; }
        public string? Telefono01 { get; set; }
        public string? Telefono02 { get; set; }
        public string? IDidentificacion { get; set; }
        public int Estatus { get; set; }
        public double Monto { get; set; }
        public string? Correo { get; set; }
        public byte[]? Imagen { get; set; }
        public string? Rutaimagen { get; set; }
        public int PagaImpuesto { get; set; }
    }
}

