using System;
using DentoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using DentoWeb.Models.Db;
using System.Linq;

namespace DentoWeb.Controllers
{
    



    public class ClienteController:Controller
    {
        private readonly DentoWebContext cnx;

        public ClienteController(DentoWebContext cnx)
        {
            this.cnx = cnx;
        }
        public ActionResult Index(){

            return View(cnx.Clientes.ToList());
        }


        [HttpGet]
        public ActionResult Create(){
            return View();
        }

        [HttpPost]
        public ActionResult Create(string nombres, string apellidos, string dni, DateTime fechaNac,
        string correo, string telefono, string usuario, string passwd){

            if(ModelState.IsValid){
                Cliente c = new Cliente();

                c.codigo = "C-"+usuario.ToUpper();

                c.nombres = nombres;

                c.apellidos = apellidos;

                c.dni = dni;
                c.fechaNac =fechaNac;
                c.correo = correo;
                
                c.telefono = telefono;
                c.usuario = usuario;
                c.passwd = passwd;

                cnx.Clientes.Add(c);
                cnx.SaveChanges();


                return RedirectToAction("Index","Home");
            }
            else{
                if(fechaNac == null){
                     ModelState.AddModelError("fechaNac","El campo de fecha de nacimiento es obligatorio");
                }else{
                    if(fechaNac.ToString("dd/mm/aaaa") == "dd/mm/aaaa"){
                        ModelState.AddModelError("fechaNac","El campo de fecha de nacimiento es obligatorio");
              
                    }
                }
                if(nombres == "" || nombres == null){
                    ModelState.AddModelError("nombres","El campo de nombre es obligatorio");
                }
                else{
                    
                    if(nombres.Length <= 3){
                        ModelState.AddModelError("nombres","Debe contener 3 caracteres minimo");
                    }
                }
                if(apellidos == "" || apellidos == null){
                    ModelState.AddModelError("apellidos","El campo de apellidos es obligatorio");
                }
                else{
                    if(apellidos.Length < 3){
                        ModelState.AddModelError("apellidos","Debe contener 3 caracteres minimo");
               
                    }
                }
                
                if(dni == "" || dni == null){
                    ModelState.AddModelError("dni","El campo de dni es obligatorio");
                }
                else{
                    if(dni.Length != 8){
                        ModelState.AddModelError("dni","Debe contener 8 caracteres");
               
                    }
                }
                
                if(correo == "" || correo == null){
                    ModelState.AddModelError("correo","El campo de correo es obligatorio");
                }

                if(telefono == "" || telefono == null){
                    ModelState.AddModelError("telefono","El campo de telefono es obligatorio");
                }
                else{

                    if(telefono.Length >= 9 && telefono.Length <= 20 && telefono != ""){
                        ModelState.AddModelError("telefono","Debe contener 9 caracteres minimo y 20 maximo");
                    }
                }

                if(usuario == "" || usuario == null){
                    ModelState.AddModelError("usuario","El campo de usuario es obligatorio");
                }
                else{
                    if(usuario.Length <= 4){
                     ModelState.AddModelError("usuario","Debe contener al menos 4 caracteres");
               
                }
                }

                if(passwd == "" || passwd == null){
                    ModelState.AddModelError("passwd","El campo de contraseña es obligatorio");
                }
                else{
                    if(passwd.Length <= 4){
                        ModelState.AddModelError("usuario","Debe contener al menos 4 caracteres");
               
                    }
                }
                return View();
            }
            
        }
    }
}