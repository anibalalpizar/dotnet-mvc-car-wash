using dotnet_mvc_car_wash.Models;
using dotnet_mvc_car_wash.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_mvc_car_wash.Controllers
{
    public class LavadoController : Controller
    {
        private static List<CarWash> carWashs = new List<CarWash>();

        // GET: LavadoController
        public ActionResult Index(string searchTerm)
        {
            var filteredLavados = carWashs;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Filter car wash based on search term
                filteredLavados = carWashs.Where(l =>
                    l.IdLavado.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    l.PlacaVehiculo.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    l.IdCliente.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    l.IdEmpleado.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    l.TipoLavado.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    l.EstadoLavado.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    l.PrecioBase.ToString().Contains(searchTerm) ||
                    l.PrecioTotal.ToString().Contains(searchTerm) ||
                    l.FechaCreacion.ToString("dd/MM/yyyy").Contains(searchTerm) ||
                    (l.Observaciones?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false)
                ).ToList();
            }

            ViewBag.SearchTerm = searchTerm;
            ViewBag.LavadoCount = carWashs.Count;
            ViewBag.FilteredCount = filteredLavados.Count;

            return View(filteredLavados);
        }

        // GET: LavadoController/Details/5
        public ActionResult Details(string id)
        {
            var lavado = GetLavadoById(id);
            if (lavado == null)
            {
                return NotFound();
            }
            return View(lavado);
        }

        // GET: LavadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LavadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarWash carWash)
        {
            try
            {
                if (carWash.TipoLavado == TipoLavado.LaJoya && (!carWash.PrecioAConvenir.HasValue || carWash.PrecioAConvenir <= 0))
                {
                    ModelState.AddModelError("PrecioAConvenir", "You must specify a price for the 'La Joya' wash.");
                }

                if (ModelState.IsValid)
                {
                    var existingLavado = GetLavadoById(carWash.IdLavado);
                    if (existingLavado == null)
                    {
                        carWash.CalculatePrices();

                        if (carWash.FechaCreacion == default(DateTime))
                        {
                            carWash.FechaCreacion = DateTime.Now;
                        }

                        carWashs.Add(carWash);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "A wash with that ID already exists.");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the wash: " + ex.Message);
            }
            return View(carWash);
        }

        // GET: LavadoController/Edit/5
        public ActionResult Edit(string id)
        {
            var lavado = GetLavadoById(id);
            if (lavado == null)
            {
                return NotFound();
            }
            return View(lavado);
        }

        // POST: LavadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, CarWash carWash)
        {
            try
            {
                if (carWash.TipoLavado == TipoLavado.LaJoya && (!carWash.PrecioAConvenir.HasValue || carWash.PrecioAConvenir <= 0))
                {
                    ModelState.AddModelError("PrecioAConvenir", "You must specify a price for the 'La Joya' wash.");
                }

                if (ModelState.IsValid)
                {
                    carWash.IdLavado = id; // Ensure the ID remains the same

                    carWash.CalculatePrices();

                    bool success = UpdateLavado(carWash);
                    if (success)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "An error occurred while creating the wash.");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the wash: " + ex.Message);
            }
            return View(carWash);
        }

        // GET: LavadoController/Delete/5
        public ActionResult Delete(string id)
        {
            var lavado = GetLavadoById(id);
            if (lavado == null)
            {
                return NotFound();
            }
            return View(lavado);
        }

        // POST: LavadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                bool success = DeleteLavado(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        private CarWash GetLavadoById(string id)
        {
            CarWash lavado = null;
            foreach (var lav in carWashs)
            {
                if (lav.IdLavado == id)
                {
                    lavado = lav;
                    break;
                }
            }
            return lavado;
        }

        private bool UpdateLavado(CarWash updatedLavado)
        {
            bool success = false;
            try
            {
                for (int i = 0; i < carWashs.Count; i++)
                {
                    if (carWashs[i].IdLavado == updatedLavado.IdLavado)
                    {
                        updatedLavado.FechaCreacion = carWashs[i].FechaCreacion;
                        carWashs[i] = updatedLavado;
                        success = true;
                        break;
                    }
                }
            }
            catch
            {
                success = false;
            }
            return success;
        }

        private bool DeleteLavado(string id)
        {
            bool success = false;
            try
            {
                CarWash lavadoToRemove = GetLavadoById(id);
                if (lavadoToRemove != null)
                {
                    carWashs.Remove(lavadoToRemove);
                    success = true;
                }
            }
            catch
            {
                success = false;
            }
            return success;
        }
    }
}