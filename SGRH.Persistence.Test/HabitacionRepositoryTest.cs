using Microsoft.EntityFrameworkCore;
using Moq;
using SGHR.Domain.Entities.Habitaciones;
using SGHR.Persistence.Context;
using SGHR.Persistence.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SGRH.Persistence.Test
{
    public class HabitacionRepositoryTest
    {
        [Fact]
        public async Task AddAsync_ShouldAddHabitacion()
        {
            var options = new DbContextOptionsBuilder<SGHRContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Base única por test
                .Options;

            using var context = new SGHRContext(options);

            // ✅ Se elimina el paso de logger y configuración porque el repositorio no lo necesita
            var repository = new HabitacionRepository(context);

            var habitacion = new Habitacion
            {
                IdHabitacion = 1,
                Numero = "101",
                Detalle = "Habitación doble",
                Precio = 120,
                Estado = true
            };

            var result = await repository.AddAsync(habitacion);

            Assert.True(result.Success);
            var allHabitaciones = await repository.GetAllAsync();
            Assert.Single(allHabitaciones);
        }
    }
}

