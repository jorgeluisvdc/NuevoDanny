using mvc_dany.Models;
using mvc_dany.Models.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_dany.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            PersonaEntities db = new PersonaEntities();

            var oPer = db.persona.AsQueryable();
            var oCur = db.curso.AsQueryable();

            /* ejercicio 1 consulta simple ***************************
            var oLista = (from p in oPer
                          select p.apellido).ToList();
            */

            /* ejercicio 2 consulta con clases ***************************
            var oLista = (from p in oPer
                          where p.nombre=="rene"
                          select new PersonaConsulta
                          {
                              Codigo = p.codigo,
                              Nombre= p.nombre + " " + p.apellido
                          }                          
                          ).ToList();
            */

            // ejercicio 3 consulta con 2 tablas ***************************
            // de nuevo aki vamos
            var oLista = (from p in oPer
                          join c in oCur on p.codigo equals c.codigo
                          select new PersonaConsulta
                          {
                              Codigo = p.codigo,
                              Nombre = p.nombre + " " + p.apellido,
                              Curso = c.descripcion,
                              Tipo = c.tipo,
                          }
                          ).ToList();
            // go go go perra askerosa!!!
            return View(oLista);
        }
    }
}