using dotnet_mvc_car_wash.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_mvc_car_wash.Controllers
{
    public class EmployeeController : Controller
    {
        // Static list to store employees in memory
        private static List<Employee> employees = new List<Employee>();

        // GET: EmployeeController
        public ActionResult Index(string searchTerm)
        {
            var filteredEmployees = employees;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Buscar por aproximación en ID, fechas y campos numéricos convertidos a string
                filteredEmployees = employees.Where(e =>
                    e.Id.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    e.BirthDate.ToString("dd/MM/yyyy").Contains(searchTerm) ||
                    e.HireDate.ToString("dd/MM/yyyy").Contains(searchTerm) ||
                    e.DailySalary.ToString().Contains(searchTerm) ||
                    e.AccumulatedVacationDays.ToString().Contains(searchTerm) ||
                    (e.TerminationDate?.ToString("dd/MM/yyyy")?.Contains(searchTerm) ?? false) ||
                    (e.SeveranceAmount?.ToString()?.Contains(searchTerm) ?? false)
                ).ToList();
            }

            ViewBag.SearchTerm = searchTerm;
            ViewBag.EmployeeCount = employees.Count;
            ViewBag.FilteredCount = filteredEmployees.Count;

            return View(filteredEmployees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(string id)
        {
            var employee = GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Check if employee with same ID already exists
                    var existingEmployee = GetEmployeeById(employee.Id);
                    if (existingEmployee == null)
                    {
                        employees.Add(employee);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "An employee with that ID already exists.");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error creating employee: " + ex.Message);
            }
            return View(employee);
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(string id)
        {
            var employee = GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employee.Id = id; // Ensure ID doesn't change
                    bool success = UpdateEmployee(employee);
                    if (success)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Could not update employee.");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error updating employee: " + ex.Message);
            }
            return View(employee);
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(string id)
        {
            var employee = GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                bool success = DeleteEmployee(id);

                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                return RedirectToAction(nameof(Index));
            }
        }

        private Employee GetEmployeeById(string id)
        {
            Employee employee = null;
            foreach (var emp in employees)
            {
                if (emp.Id == id)
                {
                    employee = emp;
                    break;
                }
            }
            return employee;
        }

        private bool UpdateEmployee(Employee updatedEmployee)
        {
            bool success = false;
            try
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    if (employees[i].Id == updatedEmployee.Id)
                    {
                        employees[i] = updatedEmployee;
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

        private bool DeleteEmployee(string id)
        {
            bool success = false;
            try
            {
                Employee employeeToRemove = GetEmployeeById(id);
                if (employeeToRemove != null)
                {
                    employees.Remove(employeeToRemove);
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