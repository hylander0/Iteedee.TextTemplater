using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteedee.TextTemplater.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string template = @"<html>
    <head>
        <title>{%DYNAMIC_TITLE%}</title>
    </head>
    <Body>
        <p>
            {%HELLO_WORLD_VALUE%}
        </p>        
        <p>
            Should be empty: '{%NOT_PROVIDE_IN_DATA%}'
        </p>
    </Body>
</html>
";

            Dictionary<string, string> Data = new Dictionary<string, string>();
            Data.Add("DYNAMIC_TITLE", "My Template Title");
            Data.Add("HELLO_WORLD_VALUE", "Hello my great big world");
            string output = Iteedee.TextTemplater.Templify.PopulateTemplate(template, Data);

            Console.WriteLine("Populated Template:");
            Console.WriteLine("");
            output.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)
                .ToList()
                .ForEach(f =>
                {
                    Console.WriteLine(f);
                });
            Console.ReadKey();

        }
    }
}
