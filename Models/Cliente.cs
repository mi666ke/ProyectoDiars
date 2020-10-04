using System;
using System.ComponentModel.DataAnnotations;

namespace DentoWeb.Models
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string codigo { get; set; }


        [Required(ErrorMessage = "El nombre es requerido...")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener minimo 3 caracteres")]
        public string nombres { get; set; }

         [Required(ErrorMessage = "El apellido es requerido...")]
        [StringLength(50,MinimumLength = 3,ErrorMessage="El apellido debe tener por lo menos 3 caracteres.")]
        public string apellidos { get; set; }

        [Required(ErrorMessage = "El dni es requerido...")]
        [RegularExpression(@"\d(8)", ErrorMessage = "Debe contener 8 caracteres")]
        public string dni { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerido...")]
        public DateTime fechaNac{get;set;}


        [Required(ErrorMessage = "El correo es requerido...")]
        public string correo { get; set; }

        [Required(ErrorMessage = "El telefono es requerido...")]
        [StringLength(20,MinimumLength=9,ErrorMessage="El telefono debe tener por lo menos 9 digitos.")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "El usuario es requerido...")]
        [StringLength(50,MinimumLength=4,ErrorMessage="El usuario debe tener por lo menos 4 caracteres.")]
        public string usuario { get; set; } 

        [Required(ErrorMessage = "La contraseña es requerida...")]
        [StringLength(200,MinimumLength=5, ErrorMessage="La contraseña debe tener por lo menos 3 caracteres.")]
        public string passwd { get; set; }
    }
}