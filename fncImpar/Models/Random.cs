namespace fncImpar.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Random
    {
        [Key]
        public int nRandom { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DateTime { get; set; }

    }
}
