using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Application.Contracts.DTO.parameters
{
    public class ReservationDTO
    {
        public long Id { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime OutDate { get; set; }

        public decimal Price { get; set; }

        public CustomerDTO Customer { get; set; }

        public PropertyDTO Property { get; set; }
    }
}
