using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalago.DTOs
{
    public record UsuarioDTO
    {
        public string Email { get; init; }
        public string Password { get; init; }
        public string CofirmPassword { get; init; }
    }
}
