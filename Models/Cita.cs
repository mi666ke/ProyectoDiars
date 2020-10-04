using System;

namespace DentoWeb.Models
{
    public class Cita
    {
        public int idCita { get; set; }
        public DateTime fecha { get; set; }
        public string horaInicio{get;set;}
        public string horaFin { get; set; }
        public string estado {get;set;}
        public int idCliente{get;set;}
        public int idDoctor{get;set;}
        public decimal monto { get; set; }



        public Cliente cliente { get; set; }
        public Doctor doctor{get;set;}
        
    }
}