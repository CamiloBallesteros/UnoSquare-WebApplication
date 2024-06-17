using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoSquare.Models.ResponseModels
{
    public class GenericResponse
    {
        public bool ErrorFlag { get; set; } = false;
        public string? SuccessMessage { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
