using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressTrainer
{
    public static class StringHelper
    {
        public static HashSet<string> StateAbbreviations = new HashSet<string>
         {
                "AL",
                "AK",
                "AZ",
                "AR",
                "CA",
                "CO",
                "CT",
                "DE",
                "FL",
                "GA",
                "HI",
                "ID",
                "IL",
                "IN",
                "IA",
                "KS",
                "KY",
                "LA",
                "ME",
                "MD",
                "MA",
                "MI",
                "MN",
                "MS",
                "MO",
                "MT",
                "NE",
                "NV",
                "NH",
                "NJ",
                "NM",
                "NY",
                "NC",
                "ND",
                "OH",
                "OK",
                "OR",
                "PA",
                "RI",
                "SC",
                "SD",
                "TN",
                "TX",
                "UT",
                "VT",
                "VA",
                "WA",
                "WV",
                "WI",
                "WY",
                "DC",
                "PR",
                "VI",
                "AS",
                "GU",
                "MP",
                "AA",
                "AE",
                "AP",
        };

        public static string RandomString(int length)
        {
            string characters = $"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz \t{Environment.NewLine}";
            StringBuilder result = new StringBuilder(length);
            var random = new Random(); 
            for(var i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]); 
            }
            return result.ToString(); 
        }
    }
}
