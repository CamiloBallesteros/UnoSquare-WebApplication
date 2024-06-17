using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoSquare.Models.ResponseModels
{
    public class UpdateResponse: GenericResponse
    {
        public int IdUpdated { get; set; }
        public List<string> FieldsUpdated { get; set; } = new List<string>();
    }
}
