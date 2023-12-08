using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Repository.Contracts.DbModel.Parameters
{
    public class PropertyOwnerDbModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Photo { get; set; }
        //public virtual ICollection<Property> Property { get; set; }
    }
}
