using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Iteedee.TextTemplater
{
    public class Templify
    {
        /// <summary>
        /// //This will match against {%DATA_KEY%} strings in the dictionary Key values
        /// </summary>
        /// <param name="template">Document containing template placeholders</param>
        /// <param name="data">Key/Value pairs Key is the placeholder (ie DATA_KEY) and value is the string to replace the key in the template.</param>
        /// <returns>Populated Template</returns>
        public static string PopulateTemplate(string template, Dictionary<string,string> data)
        {
            return ApplyTextTemplating(template, data, @"{%([^}]+)%}");
        }
        private static string ApplyTextTemplating(string templateText, Dictionary<string, string> data, string placeholderRegexPattern)
        {
            Regex re = new Regex(placeholderRegexPattern, RegexOptions.Compiled); //This will match against {%......%} strings 
            MatchCollection matches = re.Matches(templateText);
            List<String> matchList = matches.Cast<Match>().Select(s => s.Value).ToList();
            if (matches.Count > 0)
            {
                foreach (Match item in matches)
                {
                    string keyToCheck = item.Value.Trim(new Char[] { '{', '%', '}' }).ToUpper();
                    if (data.ContainsKey(keyToCheck))
                        templateText = templateText.Replace(item.Value, data[keyToCheck]);
                    else
                        templateText = templateText.Replace(item.Value, String.Empty);
                }
            }

            return templateText;
        }
    }
}
