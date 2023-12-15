using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemadeFacturacion_2023.Models;
using SistemadeFacturacion_2023.Repository.Interfaces;

namespace SistemadeFacturacion_2023.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductosRepositorycs _products;

        public ProductoController(IProductosRepositorycs products)
        {
            _products = products;
        }
        // GET: ProductoController
        public ActionResult Index()
        {
            var productos = _products.GetEntities().Select(p => new Productos()
            {

                IDProductos = p.IDProductos,
                Descripcion = p.Descripcion,
                Costo = p.Costo,
                BarCode = p.BarCode,
                CantidadEnExistencia = p.CantidadEnExistencia,
                EstatusProducto = p.EstatusProducto,
                Impuesto = p.Impuesto,
                Item = p.Item,
                PreciodeVenta = p.PreciodeVenta,
                Ruta = p.Ruta

            }).ToList();
            return View(productos);
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
