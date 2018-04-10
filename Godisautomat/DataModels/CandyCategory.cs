using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godisautomat.DataModels
{
    public class CandyCategory
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<CandyType> CandyTypes { get; set; }
    }
}
