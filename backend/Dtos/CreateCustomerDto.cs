using System.ComponentModel.DataAnnotations;

namespace backend.Dtos
{
    public class CreateCustomerDto
    {
        [Required(ErrorMessage = "El nombre propio tiene que estar especificado")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El apellido tiene que estar especificado")]
        public string LastName { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "El Mail no es correcto")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El numero tiene que estar especificado")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "El nombre de la direccion tiene que estar especificado")]
        public string Address { get; set; }


    }
}
