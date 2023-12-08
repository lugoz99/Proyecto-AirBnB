using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Application.Contracts.DTO.parameters
{
    public class PropertyOwnerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Photo { get; set; }
    }
}
