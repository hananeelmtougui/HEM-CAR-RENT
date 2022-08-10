using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lcvoiture.Models
{
    public class User
    {
        [Key]
        public int userID { get; set; }
        [Required]
        [StringLength(60)]
        public string nom_Complet { get; set; }
        [Required]
        public DateTime date_Naissance { get; set; }
        [Required]



        public int tele { get; set; }
        [Required]
        [EmailAddress]

        public string email { get; set; }
        [Required]
        public string password { get; set; }



        [DataType("image")]
        
        public string image_CIN { get; set; }
        [NotMapped]

        public HttpPostedFileBase img_CINTemp { get; set; }
        [DataType("image")]
        
        public string image_Permis { get; set; }
        [NotMapped]
        public HttpPostedFileBase img_PrmTemp { get; set; }
        public bool IsAdmin { get; set; }


    }
}