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
        public static async Task<List<CandyCategory>> LoadConfigFile(string configFolderPath)
        {
            if (!Directory.Exists(configFolderPath))
                Directory.CreateDirectory(configFolderPath);

            return await LoadCategoryConfig(configFolderPath);
        }
        
        private static async Task<List<CandyCategory>> LoadCategoryConfig(string configFolderPath)
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
                        var candyTypeObject = new CandyType
                        {
                            Category = candyCategory,
                            Name = yamlFile.GetString($"{root}.{child}.candytypes.{candyType}.name"),
                            ImageUrl = yamlFile.GetString($"{root}.{child}.candytypes.{candyType}.imageurl"),
                            Price = yamlFile.GetString($"{root}.{child}.candytypes.{candyType}.price"),
                            Ingredients = new List<Ingredient>(),
                            Sizes = new List<string>(),
                        };

                        foreach (var ingredient in yamlFile.GetChildren($"{root}.{child}.candytypes.{candyType}.ingredients"))
                        {
                            candyTypeObject.Ingredients.Add(new Ingredient
                            {
                                Name = yamlFile.GetString($"{root}.{child}.candytypes.{candyType}.ingredients.{ingredient}.name"),
                                IsAllergic = bool.Parse(yamlFile.GetString($"{root}.{child}.candytypes.{candyType}.ingredients.{ingredient}.allergic")),
                                WarningImagePath = yamlFile.GetString($"{root}.{child}.candytypes.{candyType}.ingredients.{ingredient}.warningimage"),
                            });
                        }

                        foreach (var size in yamlFile.GetChildren($"{root}.{child}.candytypes.{candyType}.sizes"))
                        {
                            candyTypeObject.Sizes.Add(yamlFile.GetString($"{root}.{child}.candytypes.{candyType}.sizes.{size}.name"));
                        }

                        candyTypes.Add(candyTypeObject);
                    }
                    candyCategory.CandyTypes = candyTypes;

                    candyCategories.Add(candyCategory);
                }
            }

            return candyCategories;
        }
    }
}
