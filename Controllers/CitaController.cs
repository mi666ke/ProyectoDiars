using System;
using System.Linq;
using DentoWeb.Models;
using DentoWeb.Models.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DentoWeb.Controllers
{
    public class CitaController:Controller
    {
        private DentoWebContext cnx;
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
        string horaFin, int idCliente, int idDoctor){

            Cita cita = new Cita();

            cita.fecha = fecha;
            cita.horaInicio = horaInicio;
            cita.horaFin = horaFin;

            cita.estado = "Activo";
            cita.idCliente = idCliente;
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