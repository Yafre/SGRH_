using System.Threading.Tasks;
using SGHR.Application.Dtos.Cliente;
using SGHR.Application.Services;
using SGHR.Persistence.Interfaces;
using SGRH.Application.Test.Services;
using Xunit;

public class ClienteServiceTests : ServiceTestBase
{
    private readonly ClienteService _clienteService;
    private readonly IClienteRepository _clienteRepository;

    public ClienteServiceTests()
    {
        _clienteRepository = GetRequiredService<IClienteRepository>(); // ✅ Obtiene el repo con inyección de dependencias
        _clienteService = new ClienteService(_clienteRepository);
    }

    [Fact]
    public async Task CreateCliente_ShouldReturnError_WhenClienteIsNull()
    {
        // Arrange
        SaveClienteDto? clienteDto = null; // ✅ Se marca como nullable
        string message = "El objeto cliente es requerido.";

        // Act
        var result = await _clienteService.CreateAsync(clienteDto!);

        // ✅ Se usa el tipo correcto para verificar el mensaje
        Assert.NotNull(result);
        Assert.False(result.Success);
        Assert.Equal(message, result.Message);  // ✅ Ahora sí tiene Message porque `result` es `OperationResult`
    }

    [Fact]
    public async Task GetClienteById_ShouldReturnError_WhenIdNotExists()
    {
        // Arrange
        int clienteId = 999; // ID que no existe en la BD

        // Act
        var result = await _clienteService.GetByIdAsync(clienteId);

        // ✅ Se asegura que `result` es `null` cuando el ID no existe
        Assert.Null(result);
    }
}
