using System;
using System.Linq;
using DentoWeb.Models;
using DentoWeb.Models.Db;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DentoWeb.Controllers
{
    

    [Authorize]
    public class CitaController:Controller
    {
        private readonly DentoWebContext cnx;
        public CitaController(DentoWebContext cnx)
        {
            this.cnx = cnx;
        }

        [HttpGet]
        public ActionResult Create(){
            ViewBag.Clientes = cnx.Clientes.ToList();
            ViewBag.Doctores = cnx.Doctores.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(DateTime fecha,string horaInicio,
        string horaFin, int idDoctor){

            Cita cita = new Cita();
            var claim = HttpContext.User.Claims.FirstOrDefault();    
            var nombre = cnx.Clientes.Where( o => o.usuario == claim.Value.ToString()).FirstOrDefault();
            cita.idCliente = nombre.idCliente;   
            cita.fecha = fecha;
            cita.horaInicio = horaInicio;
            cita.horaFin = horaFin;

            cita.estado = "Activo";
            
            cita.idDoctor = idDoctor;

            cita.monto = (decimal)35.5;


            cnx.Citas.Add(cita);
            cnx.SaveChanges();

            return RedirectToAction("Index","Home");
        }

        public ActionResult Index(){
            var x = cnx.Citas.Include( o => o.doctor).Include(o => o.cliente).ToList();
            return View(x);
        }

    }
}