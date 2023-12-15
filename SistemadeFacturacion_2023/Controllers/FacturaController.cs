using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemadeFacturacion_2023.Helpers;
using SistemadeFacturacion_2023.Models;
using SistemadeFacturacion_2023.Repository.Interfaces;
using System.Data.SqlTypes;

namespace SistemadeFacturacion_2023.Controllers
{
    public class FacturaController : Controller
    {
        private readonly IFacturaRepository _facturarep;
        private readonly IClienteRepository _clienterep;
        private readonly GenerarPDF _generarPDF;

        public FacturaController(IFacturaRepository facturarep, IClienteRepository clienterep, GenerarPDF generarPDF)
        {
            _facturarep = facturarep;
            _clienterep = clienterep;
            _generarPDF = generarPDF;
        }




        // GET: FacturaController
        public ActionResult Index()
        {
            var facturas = _facturarep.GetEntities().Select(f => new Factura()
            {
                IDFactura = f.IDFactura,
                Codigo = f.Codigo,
                Fecha = f.Fecha,
                Articulo = f.Articulo,
                Cantidad = f.Cantidad,
                PrecioDeVenta = f.PrecioDeVenta,
                Impuesto = f.Impuesto,
                MontoPorLinea = f.MontoPorLinea,
                IdCliente = f.IdCliente,
            }).Where(x => x.IsDeleted == false).ToList();
            return View(facturas);

        }

        public IActionResult Filtro(int codigo)
        {
            var lista = _facturarep.GetEntities();

            var filtro = lista.Where(l => l.IDFactura == codigo).Where(x => x.IsDeleted == false).ToList();

            return View("Index", filtro);
        }




        // GET: FacturaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FacturaController/Create
        public ActionResult Create()
        {
            ViewBag.clienteList = _clienterep.GetEntities();
            return View();
        }

        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Factura factura)
        {
            try
            {
                Factura nuevaFactura = new Factura()
                {
                    Fecha = DateTime.Today.Date.ToString("dd/MM/yyyy"),
                    Codigo = factura.Codigo,
                    Articulo = factura.Articulo,
                    Cantidad = factura.Cantidad,
                    PrecioDeVenta = factura.PrecioDeVenta,
                    Impuesto = factura.Impuesto,
                    MontoPorLinea = factura.MontoPorLinea,
                    IdCliente = factura.IdCliente,
                };

                _facturarep.Save(nuevaFactura);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.clienteList = _clienterep.GetEntities();
                return View();
            }
        }


        // GET: FacturaController/Edit/5
        public ActionResult Edit(int id)
        {
            var factura = _facturarep.GetEntityByID(id);
            ViewBag.clienteList = _clienterep.GetEntities();
            return View("Create",factura);
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Factura factura)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _facturarep.Update(factura);
                    return RedirectToAction(nameof(Index));
                }

                return View("Create",factura);
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {

                var factura = _facturarep.GetEntityByID(id);
                factura.IsDeleted = true;
                _facturarep.Update(factura);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Imprimir(int Id)
        {
            var pdfStream = _generarPDF.GeneratePDF(Id);
            if (pdfStream == null)
            {
                return NotFound();
            }

            pdfStream.Position = 0;

            return File(pdfStream, "application/pdf", $"factura_{Id}.pdf");
        }


    }
}