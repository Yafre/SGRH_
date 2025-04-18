﻿using System.ComponentModel.DataAnnotations;

namespace SGHR.Domain.Entities.Habitaciones
{
    public class EstadoHabitacion
    {
        [Key]
        public int IdEstadoHabitacion { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Habitacion> Habitaciones { get; set; } = [];
    }
}
