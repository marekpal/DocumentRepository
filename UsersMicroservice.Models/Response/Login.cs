using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersMicroservice.Models.Response
{
    /// <summary>
    /// Klasa odpowiedzi na żądanie zalogowania do systemu
    /// </summary>
    public class Login
    {
        /// <summary>
        /// Token dostępowy (gwarantuje dostęp do chronionych endpointów API)
        /// </summary>
        public string AccessToken { get; set; }
    }
}
