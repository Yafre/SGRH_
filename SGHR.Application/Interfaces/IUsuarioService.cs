using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGHR.Application.Base;
using SGHR.Application.Dtos.Usuario;
using SGHR.Domain.Base;

namespace SGHR.Application.Interfaces
{
    public interface IUsuarioService : IBaseService<UsuarioDto, SaveUsuarioDto, UpdateUsuarioDto, RemoveUsuarioDto>

    {
    }

}
