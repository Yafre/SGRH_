public class OperationResult
{
    public OperationResult()
    {
        this.Success = true;
    }
    public string Message { get; set; } = string.Empty; // para evitar valores nulos con un valor predeterminado
    public bool Success { get; set; }
    public dynamic Data { get; set; } = null!;
}
