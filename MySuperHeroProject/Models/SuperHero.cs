using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySuperHeroProject.Models
{
    public class SuperHero
    {
        [Key]
        public int id { get; set; }
        public string name {get;set;}
        public string alterEgo { get; set; }
        public string ability { get; set; }
        public string secondaryAbility { get; set; }
        public string catchPhrase { get; set; }
    }
}
