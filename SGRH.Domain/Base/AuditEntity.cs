namespace SGRH.Domain.Base
{
    public abstract class AuditEntity
    {
        protected AuditEntity() 
        { 
            this.Estatus = true;
        
        }
        public DateTime FechaCreacion {get; set;} 
        public DateTime? FechaModificacion {get; set;}
        public int? UsuarioModificación {get; set;}
        public bool  Estatus {get; set;}
}
}
