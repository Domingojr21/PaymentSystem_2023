
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SistemadeFacturacion_2023.Repository.Interfaces;

namespace SistemadeFacturacion_2023.Helpers
{
    public class GenerarPDF
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly IClienteRepository _clienteRepository;

        public GenerarPDF(IFacturaRepository facturaRepository, IClienteRepository clienteRepository)
        {
            _facturaRepository = facturaRepository;
            _clienteRepository = clienteRepository;
        }

        public MemoryStream GeneratePDF(int Id)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            var facturaDetails = _facturaRepository.GetEntityByID(Id);
            var cliente = _clienteRepository.GetEntityByID(facturaDetails.IdCliente);
           
            var document = Document.Create(container =>
            container.Page(page =>
            {
                page.Margin(1, QuestPDF.Infrastructure.Unit.Centimetre);
                page.Header().AlignCenter().Text("Detalle de Factura").Bold().FontSize(30);
                page.Content().AlignCenter().Column(
                    column =>
                    {
                        column.Item().Text($"");
                        column.Item().Text($"Fecha: {facturaDetails.Fecha}");
                        column.Item().Text($"Id de la factura: {facturaDetails.IDFactura}");
                        column.Item().Text($"Nombre del Cliente: {cliente.Nombre}");
                        column.Item().Text($"Cantidad : {facturaDetails.Cantidad}");
                        column.Item().Text($"Código : {facturaDetails.Codigo}");
                        column.Item().Text($"Precio de Venta : {facturaDetails.PrecioDeVenta}");
                        column.Item().Text($"Impuesto : {facturaDetails.Impuesto}");
                        column.Item().Text($"Articulos : {facturaDetails.Articulo}");
                        column.Item().Text($"Monto Por línea : {facturaDetails.MontoPorLinea}");
                    });
            }));

            var memoryStream = new MemoryStream();
            document.GeneratePdf(memoryStream);
            memoryStream.Position = 0;

            return memoryStream;
        }
    }
}
