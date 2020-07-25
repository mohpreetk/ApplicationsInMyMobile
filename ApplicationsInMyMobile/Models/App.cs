using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationsInMyMobile.Models
{
    public class App
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public int ReleaseYear { get; set; }
        public float RatingOnPlay { get; set; }
    }
}
