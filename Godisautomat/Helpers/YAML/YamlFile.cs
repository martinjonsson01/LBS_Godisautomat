using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.RepresentationModel;

namespace Godisautomat.Helpers.YAML
{
    public class YamlFile
    {
        private YamlStream _yaml;
        private YamlMappingNode _rootNode;

        public YamlFile(string file)
        {
            _yaml = new YamlStream();
            _yaml.Load(new StringReader(File.ReadAllText(file)));

            _rootNode = (YamlMappingNode)_yaml.Documents[0].RootNode;
        }

        public string GetString(string path)
        {
            string[] splitPath = path.Split('.');

            YamlMappingNode currentNode = _rootNode;

            for (int i = 0; i < splitPath.Length - 1; i++)
            {
                YamlNode outputNode = null;
                currentNode.Children.TryGetValue(new YamlScalarNode(splitPath[i]), out outputNode);

                if (outputNode == null)
                {
                    return null;
                }
                else
                {
                    currentNode = (YamlMappingNode)outputNode;
                }
            }

            YamlNode lastNode = null;
            currentNode.Children.TryGetValue(new YamlScalarNode(splitPath[splitPath.Length - 1]), out lastNode);

            if (lastNode == null)
            {
                return null;
            }
            else
            {
                return lastNode.ToString();
            }
        }

        public List<string> GetChildren(string path)
        {
            string[] splitPath = path.Split('.');

            YamlMappingNode currentNode = _rootNode;

            foreach (string currentPath in splitPath)
            {
                YamlNode outputNode = null;
                currentNode.Children.TryGetValue(new YamlScalarNode(currentPath), out outputNode);

                if (outputNode == null)
                {
                    return null;
                }
                else
                {
                    currentNode = (YamlMappingNode)outputNode;
                }
            }

            List<string> children = new List<string>();
            foreach (var yamlNode in currentNode.Children)
            {
                children.Add(((YamlScalarNode)yamlNode.Key).Value);
            }

            return children;
        }
    }
}
