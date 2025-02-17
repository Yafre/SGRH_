namespace SGRH.Domain.Base
{
    /// <summary>
    /// Representa el resultado de una operación con información adicional.
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// Constructor que inicializa la operación como exitosa por defecto.
        /// </summary>
        public OperationResult()
        {
            this.Success = true;
        }

        /// <summary>
        /// Indica si la operación fue exitosa.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Mensaje asociado al resultado de la operación.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Datos adicionales retornados por la operación.
        /// </summary>
        public dynamic? Data { get; set; }
    }
}
