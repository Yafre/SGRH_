using SGHR.Application.Dtos.Habitacion;
using SGHR.Application.Dtos.Commons;

namespace SGHR.Web.Models
{
    public class HabitacionFormViewModel
    {
        public UpdateHabitacionDto Habitacion { get; set; } = new();

        public List<DropdownDto> Estados { get; set; } = new();
        public List<DropdownDto> Pisos { get; set; } = new();
        public List<DropdownDto> Categorias { get; set; } = new();
    }
}
