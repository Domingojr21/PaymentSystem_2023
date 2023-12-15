using Microsoft.AspNetCore.Mvc;
using SistemadeFacturacion_2023.Helpers;
using SistemadeFacturacion_2023.Models;
using SistemadeFacturacion_2023.Repository.Interfaces;

namespace SistemadeFacturacion_2023.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClienteRepository _clienterep;

        public ClientController(IClienteRepository clienterep)
        {
            _clienterep = clienterep;
        }

        // GET: ClientController
        public ActionResult Index()
        {
            var cliente = _clienterep.GetEntities();
            return View("Index",cliente);
        }


        public IActionResult Filtro(int Id)
        {
            var lista = _clienterep.GetEntities();

            var filtro = lista.Where(l => l.IDcliente == Id).ToList();

            return View("Index", filtro);
        }

        // GET: FacturaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Clientes cliente)
        {
            try
            {
                _clienterep.Save(cliente);
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
            var factura = _clienterep.GetEntityByID(id);
            return View("Create", factura);
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Clientes cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienterep.Update(cliente);
                    return RedirectToAction(nameof(Index));
                }

                return View("Create", cliente);
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
                var clientes = _clienterep.GetEntityByID(id);
                _clienterep.Remove(clientes);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
