using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaWebEmpleado.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly EmpleadoDBContext context;

        public EmpleadoController(EmpleadoDBContext context)
        {
            this.context = context;
        }



        //GET /empleado
        //GET /empleado/index
        [HttpGet]
        public IActionResult Index()
        {
            //lista de empleados
            var empleado = context.Empleados.ToList();

            //enviar los empleados a la vista
            return View(empleado);
        }

        //GET /empleado/titulo
        [HttpGet("{titulo}")]
        public ActionResult<IEnumerable<Empleado>> GetBytitulo(string titulo)
        {
            var empleado = (from a in context.Empleados
                            where a.Titulo == titulo
                            select a).ToList();
            return View("GetByTitulo", empleado);
        }

        //GET: empleado/Create
        [HttpGet]
        public ActionResult Create()
        {
            Empleado empleado = new Empleado();

            return View("Create", empleado);//devolver al cliente html(vista)
        }

        //POST: empleado/Create
        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                context.Empleados.Add(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        private Empleado TraerUno(int id)
        {
            return context.Empleados.Find(id);
        }

        private Empleado TraerUno(string titulo)
        {
            return context.Empleados.Find(titulo);
        }

        // empleado/delete/1
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var empleado = TraerUno(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", empleado);
            }
        }

        // empleado/delete/1
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var empleado = TraerUno(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                context.Empleados.Remove(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        //GET: empleado/Edit/2
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var empleado = TraerUno(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                return View("Edit", empleado);
            }
        }

        //POST: empleado/Edit/2
        [ActionName("Edit")]
        [HttpPost]
        public ActionResult EditConfirmacion(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                context.Entry(empleado).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View(empleado);

        }

        //GET: empleado/Details/4
        [HttpGet]
        public ActionResult Details(int id)
        {
            var empleado = TraerUno(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                return View("Details", empleado);
            }
        }

    }
}
