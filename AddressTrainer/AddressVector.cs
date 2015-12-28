using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; 
using System.Threading.Tasks;
using Encog.ML.Data;
using Encog.Util.KMeans;

namespace AddressTrainer
{
    public class AddressVector : Encog.ML.Data.IMLData
    {
        #region staticHelpers
        private static Dictionary<string, int> PropertyNamesToIxes = new Dictionary<string, int>
        {
            {"startsWithNumber", 0 },
            {"containsNewline", 1 }, 
            {"containsFiveDigits", 2 },
            {"length", 3 }
        };

        public static bool ContainsStateAbbrev(string candidate)
        {
            return StringHelper.StateAbbreviations.Any(abbr =>
            {
                var r = RegexFromStateAbbr(abbr);
                return r.IsMatch(candidate);
            }); 
        }
        private static Regex RegexFromStateAbbr(string abbr)
        {
            if(abbr.Length != 2)
            {
                throw new ArgumentException("abbr must be 2 digit state abbreviation"); 
            }
            return new Regex($"\\b{Char.ToUpper(abbr[0])}\\.?[{Char.ToUpper(abbr[1])}{Char.ToLower(abbr[1])}]\\.?\\b"); 
        }


        #endregion

        #region fields
        private double[] data;
        private bool isAddress;
        private string originalInput;
        private Regex MatchFiveDigits = new Regex(@"\d{5}"); 

        #endregion

        #region Private Methods 
        private void setProp(string propName, double value)
        {
            this.data[PropertyNamesToIxes[propName]] = value; 
        }

        private bool DoesStringContainFiveDigits(string candidate)
        {
            return MatchFiveDigits.IsMatch(candidate); 
        }

        private void SetAllProps(string candidate)
        {
            this.setProp("startsWithNumber", (Char.IsNumber(candidate[0]) ? 1.0 : 0.0));
            this.setProp("containsNewline", (
                (
                    candidate.Contains(Environment.NewLine)
                    || candidate.Contains("<br")
                    || candidate.Contains("\n") 
                    || candidate.Contains("\r")
                ) ? 1.0 : 0.0));

            this.setProp("containsFiveDigits", DoesStringContainFiveDigits(candidate) ? 1.0 : 0.0);
            this.setProp("length", candidate.Length); 

        }

        #endregion

        #region constructors
        public AddressVector(string candidate, bool isAddress)
        {
            this.data = new double[PropertyNamesToIxes.Count]; 
            this.isAddress = isAddress;
            this.originalInput = candidate;
            this.SetAllProps(candidate); 
        }


        #endregion

        #region IMLData
        double IMLData.this[int x]
        {
            get
            {
                return data[x]; 
            }
        }

        int IMLData.Count
        {
            get
            {
                return this.data.Length; 
            }
        }

        object ICloneable.Clone()
        {
            throw new NotImplementedException();
        }

        void IMLData.CopyTo(double[] target, int targetIndex, int count)
        {
            throw new NotImplementedException();
        }

        ICentroid<IMLData> ICentroidFactory<IMLData>.CreateCentroid()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
