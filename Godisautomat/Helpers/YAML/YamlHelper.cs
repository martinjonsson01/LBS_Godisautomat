using Godisautomat.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Godisautomat.Helpers.YAML
{
    public static class YamlHelper
    {
        public static async Task<List<CandyCategory>> SetUpConfigFile(string configFolderPath)
        {
            if (!Directory.Exists(configFolderPath))
                Directory.CreateDirectory(configFolderPath);

            return await SetUpCategoryConfig(configFolderPath);
        }
        
        private static async Task<List<CandyCategory>> SetUpCategoryConfig(string configFolderPath)
        {
            var filePath = $"{configFolderPath}{Path.DirectorySeparatorChar}candycategories.yaml";
            if (!File.Exists(filePath))
                File.Create(filePath).Dispose();

            var candyCategories = new List<CandyCategory>();
            var root = "candycategories";

            var yamlFile = new YamlFile(filePath);
            if (yamlFile.GetString(root) != null)
            {
                foreach (var child in yamlFile.GetChildren(root))
                {
                    var candyCategory = new CandyCategory
                    {
                        Name = yamlFile.GetString($"{root}.{child}.name"),
                        ImageUrl = yamlFile.GetString($"{root}.{child}.imageurl"),
                    };

                    var candyTypes = new List<CandyType>();
                    foreach (var candyType in yamlFile.GetChildren($"{root}.{child}.candytypes"))
                    {
                        candyTypes.Add(new CandyType
                        {
                            Name = yamlFile.GetString($"{root}.{child}.candytypes.{candyType}.name"),
                            ImageUrl = yamlFile.GetString($"{root}.{child}.candytypes.{candyType}.imageurl"),
                        });
                    }
                    candyCategory.CandyTypes = candyTypes;

                    candyCategories.Add(candyCategory);
                }
            }

            return candyCategories;
        }
    }
}
