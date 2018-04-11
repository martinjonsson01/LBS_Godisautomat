using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godisautomat.DataModels
{
    public class CandyType
    {
        public CandyCategory Category { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string ImageUrl { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Sizes { get; set; }
    }
}
