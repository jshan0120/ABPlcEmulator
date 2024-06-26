using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AbPlcEmulator.Models
{
    public static class TagFileManager
    {
        private static string _tagFormat = @"(?<name>[a-zA-Z0-9_]+):(?<type>SINT|INT|DINT|LINT|REAL|LREAL|STRING|BOOL)\[(?<size>[1-9][0-9]*)\]";
        private static Regex _tagRegex = new Regex(_tagFormat);

        public static Dictionary<string, TagInfo> LoadFromFile(string path)
        {
            string text = File.ReadAllText(path);

            Dictionary<string, TagInfo> tags = new Dictionary<string, TagInfo>();

            MatchCollection matches = _tagRegex.Matches(text);
            foreach (Match match in matches)
            {
                string name = match.Groups["name"].Value;
                string type = match.Groups["type"].Value;
                string size = match.Groups["size"].Value;

                TagInfo tag = new TagInfo(name, type, size);
                tags.Add(name, tag);
            }

            return tags;
        }
        
        public static void SaveToFile(string path, Dictionary<string, TagInfo> tags)
        {
            string text = string.Empty;

            foreach (TagInfo tag in tags.Values)
            {
                string line = $"{tag.Name}:{tag.Type}[{tag.Size}]";
                text += line + Environment.NewLine;
            }

            File.WriteAllText(path, text);
        }
    }
}
