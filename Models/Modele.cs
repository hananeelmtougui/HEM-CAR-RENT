using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lcvoiture.Models
{
    public class Modele
    {
        [Key]
        public int modeleID { get; set; }
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string nom { get; set; }



        [StringLength(50)]
        public string serie { get; set; }
    }
}