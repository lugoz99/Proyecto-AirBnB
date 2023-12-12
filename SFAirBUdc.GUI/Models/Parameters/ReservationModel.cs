using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SFAirBUdc.GUI.Models.Parameters
{
    public class ReservationModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Enter Date")]
        public DateTime EnterDate { get; set; }

        [Required]
        [DisplayName("Out Date")]
        public DateTime OutDate { get; set; }
        [Required]

        [DisplayName("Price")]
        public decimal Price { get; set; }

        [DisplayName("Property")]
        [Required]
        public PropertyModel Property { get; set; }


        [DisplayName("Customer")]
        [Required]
        public CustomerModel Customer { get; set; }
        public IEnumerable<PropertyModel> PropertyList { get; set; }

        public IEnumerable<CustomerModel> CustomerList { get; set; }
    }
}