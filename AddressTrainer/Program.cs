using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; 
using System.Threading.Tasks;

namespace AddressTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\Will\Documents\Encog\AddressTrainer\Random Street Address Generator.html";
            var str = File.ReadAllText(path);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(str);

           var addresses = doc.DocumentNode.Descendants()
                .Where(d =>
                {
                    return
                        d != null
                        && d.ParentNode != null
                        && d.ParentNode.Name == "li"
                        && d.Name == "div"
                        && d.InnerText.Any(ch => Char.IsNumber(ch));
                })
                .Select(d => d.InnerHtml)
                .Select(html => new AddressVector(html, true))
                .ToList();

            string cheese = "tasty"; 
             
        }
    }
}
