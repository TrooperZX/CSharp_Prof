using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthPlus.DataBase.Entities
{
    public class Vaccine : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public List<Vaccination> Vaccinations { get; set; }
    }
}
