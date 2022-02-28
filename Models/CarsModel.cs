using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cars.Models
{
    public class CarsModel
    {
        public int ID { get; set; }

        [Required] // Decorator/Data annotation
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        
        [Required]
        [DisplayName  ("Appears in this movie")]
        public string Owner { get; set; }
        
        [Required]
        public string AppearsIn { get; set; }
        

        public CarsModel()
        {
            ID = -1;
            Name = "Nothing";
            Description = "Nothing yet";
            Owner = "No one";
            AppearsIn = "NoWhere";
        }

        public CarsModel(int iD, string name, string description, string owner, string appearsIn)
        {
            ID = iD;
            Name = name;
            Description = description;
            Owner = owner;
            AppearsIn = appearsIn;
        }
    }
}