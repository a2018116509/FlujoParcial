using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiDoble.Models
{
    public class Random
    {
        [Key]
        public int nRandom { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DateTime { get; set; }

    }
}
