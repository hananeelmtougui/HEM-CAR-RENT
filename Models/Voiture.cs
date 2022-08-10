using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lcvoiture.Models
{
    public class Voiture
    {
        public enum TypeCarburant
        {
            ParDefaut,
            Essencee,
            Diesel
        }
        [Key]
        public int voitureID { get; set; }
        [Required]



        public string matricule { get; set; }
        [Required]
        [DisplayName("Mise En Circulation")]
        public DateTime date_Mise_En_Circulation { get; set; }
        [Required]
        [Range(100, 600)]
        [DisplayName("Prix/Jour")]
        public int prix_Par_Jour { get; set; }
        public TypeCarburant? carburant { get; set; }
        [DataType("image")]
        
        public string image { get; set; }

        [NotMapped]

        public HttpPostedFileBase img_Temp { get; set; }

        public int modeleID { get; set; }
        public virtual Modele Modele { get; set; }



        public int categorieID { get; set; }



        public virtual Categorie Categorie { get; set; }
    }
}