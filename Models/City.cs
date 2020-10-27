using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab04.Models
{
    public class City
    {
        [Key]
   
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int Population { get; set; }

        [ForeignKey("Province")]
        public string ProvinceCode { get; set; }
        public Province Province { get; set; }


   
    }

}
