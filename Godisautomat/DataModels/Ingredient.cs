using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Godisautomat.DataModels
{
    public class Ingredient
    {
        public string Name { get; set; }
        public bool IsAllergic { get; set; }
        public string WarningImagePath { get; set; }
    }
}
