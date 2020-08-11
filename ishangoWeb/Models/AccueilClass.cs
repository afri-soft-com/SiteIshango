using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ishangoWeb.Models
{
    public class AccueilClass
    {
        public int id { get; set; }
        public  byte imageSlide1 { get; set; }
        public byte imageSlide2 { get; set; }


        public byte imageEvenement1 { get; set; }
        public string titreEvenement1 { get; set; }
        public string descriptionEvenement1 { get; set; }

        public byte imageEvenement2 { get; set; }
        public string titreEvenement2 { get; set; }
        public string descriptionEvenement2 { get; set; }

        public byte imageEvenement3 { get; set; }
        public string titreEvenement3 { get; set; }
        public string descriptionEvenement3 { get; set; }

    }
}
