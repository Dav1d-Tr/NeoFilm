using System.ComponentModel.DataAnnotations;

namespace NeoFilm.Shared.Entities
{
    public class User
    {
        [Display(Name = "Número de Documento (DNI)")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [MinLength(10, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo {0} solo puede contener números.")]
        public string Id { get; set; } = null!;

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [MinLength(2, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [MinLength(2, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres.")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [EmailAddress(ErrorMessage = "El campo {0} no tiene un formato válido.")]
        public string Email { get; set; } = null!;

        [Display(Name = "Confirmar Correo Electrónico")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Compare("Email", ErrorMessage = "El correo y la confirmación no coinciden.")]
        public string ValidateEmail { get; set; } = null!;

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [MinLength(8, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
            ErrorMessage = "La contraseña debe tener al menos una mayúscula, una minúscula, un número y un carácter especial.")]
        public string Password { get; set; } = null!;

        [Display(Name = "Confirmar Contraseña")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La contraseña y la confirmación no coinciden.")]
        public string ValidatePassword { get; set; } = null!;

        [Display(Name = "Número de Teléfono")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Phone(ErrorMessage = "El campo {0} no tiene un formato válido.")]
        public string PhoneNumber { get; set; } = null!;

        [Display(Name = "Tipo de Documento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int DocumentTypeId { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int RoleId { get; set; }

        public Role? Role { get; set; }
        public DocumentType? DocumentType { get; set; }

        public ICollection<Bill>? Bills { get; set; }
    }
}
