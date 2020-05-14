using System.ComponentModel.DataAnnotations;

namespace people_api.Models
{
    public class People
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
            ErrorMessage = "Email está em um formato inválido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DataType(DataType.PhoneNumber)]
        public long Phone { get; set; }
    }
}
