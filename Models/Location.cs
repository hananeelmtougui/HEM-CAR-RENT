﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lcvoiture.Models
{
    public class Location
    {
        [Key]
        public int locationID { get; set; }
        [Required]
        [Display(Name = "Date de début")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "Date de fin")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int voitureID { get; set; }
        public virtual Voiture Voiture { get; set; }
        public int userID { get; set; }



        public virtual User User { get; set; }
    }
}