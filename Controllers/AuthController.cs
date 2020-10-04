using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using DentoWeb.Models.Db;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DentoWeb_master.Controllers
{
    public class AuthController:Controller
    {
    private DentoWebContext cnx;
        public AuthController(DentoWebContext cnx)
        {
            this.cnx = cnx;
        }

        [HttpGet]
        public ActionResult Login(){
            return View();
        }
        [HttpPost]
        public ActionResult Login(string usuario, string passwd){

            var x = cnx.Clientes.Where(o => o.usuario == usuario && o.passwd == passwd).FirstOrDefault();

            if(x != null){
                 var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, usuario)
                };
                var claimsIdentity = new ClaimsIdentity(claims,"Login");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                
                HttpContext.SignInAsync(claimsPrincipal);
                
                return RedirectToAction("Index","Home");
            }
            else{
                return View();
            }
        }
    }
}