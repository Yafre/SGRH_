using System.Threading.Tasks;
using SGHR.Application.Dtos.Habitacion;
using SGHR.Application.Services;
using SGHR.Domain.Entities;
using SGHR.Domain.Entities.Habitaciones;
using SGHR.Persistence.Interfaces;
using SGRH.Application.Test.Services;
using Xunit;

public class HabitacionServiceTests : ServiceTestBase
{
    private readonly HabitacionService _habitacionService;
    private readonly IHabitacionRepository _habitacionRepository;

    public HabitacionServiceTests()
    {
        _habitacionRepository = GetRequiredService<IHabitacionRepository>();
        _habitacionService = new HabitacionService(_habitacionRepository);

        _context.Habitaciones.Add(new Habitacion
        {
            IdHabitacion = 1,
            Numero = "101",
            Estado = true
        });

        _context.SaveChanges();
    }

    [Fact]
    public async Task CreateHabitacion_ShouldReturnError_WhenHabitacionIsNull()
    {
        SaveHabitacionDto? habitacionDto = null;
        string expectedMessage = "El objeto habitación es requerido.";

        var result = await _habitacionService.CreateAsync(habitacionDto!);

        Assert.NotNull(result);
        Assert.False(result.Success);
        Assert.Equal(expectedMessage, result.Message);
    }

    [Fact]
    public async Task GetHabitacionById_ShouldReturnError_WhenIdNotExists()
    {
        int habitacionId = 999;

        var result = await _habitacionService.GetByIdAsync(habitacionId);

        Assert.Null(result);
    }

    [Fact]
    public async Task GetHabitacionById_ShouldReturnHabitacion_WhenIdExists()
    {
        int habitacionId = 1;

        var result = await _habitacionService.GetByIdAsync(habitacionId);

        Assert.NotNull(result);
        Assert.Equal("101", result.Numero);
    }
}
