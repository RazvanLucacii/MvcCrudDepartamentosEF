using Microsoft.AspNetCore.Mvc;
using MvcCrudDepartamentosEF.Models;
using MvcCrudDepartamentosEF.Repositories;

namespace MvcCrudDepartamentosEF.Controllers
{
    public class DepartamentosController : Controller
    {
        RepositoryDepartamento repoDept;

        public DepartamentosController(RepositoryDepartamento repo)
        {
            this.repoDept = repo;
        }
        public IActionResult Index()
        {
            List<Departamento> departamentos = this.repoDept.GetDepartamentos();
            return View(departamentos);
        }

        public IActionResult Details(int idDepartamento)
        {
            Departamento departamento = this.repoDept.FindDepartamento(idDepartamento);
            return View(departamento);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Departamento departamento)
        {
            this.repoDept.InsertDepartamento(departamento.idDepartamento, departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }

        public IActionResult Modificar(int idDepartamento)
        {
            Departamento departamento = this.repoDept.FindDepartamento(idDepartamento);
            return View(departamento);
        }

        [HttpPost]
        public IActionResult Modificar(Departamento departamento)
        {
            this.repoDept.ModificarDepartamento(departamento.idDepartamento, departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int idDepartamento)
        {
            this.repoDept.DeleteDepartamento(idDepartamento);
            return RedirectToAction("Index");
        }
    }
}
