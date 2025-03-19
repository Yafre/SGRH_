﻿namespace SGHR.Domain.Base
{
    public class OperationResult
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; }
    }
}
