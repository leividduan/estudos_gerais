using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalago.DTOs
{
    public record UsuarioToken
    {
        public bool Authenticated { get; init; }
        public DateTime Expiration { get; init; }
        public string Token { get; init; }
        public string Message { get; init; }
    }
}
