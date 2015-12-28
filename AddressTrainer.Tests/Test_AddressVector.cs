using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit; 

namespace AddressTrainer.Tests
{
    
    public class Test_AddressVector
    {
        [Theory]
        [InlineData("MT", true)]
        [InlineData("Alexandria, VA", true)]
        [InlineData("cheeseburgers", false)]
        [InlineData("Alexandria, Virginia", false)]
        public void ContainsStateAbbrReturnsCorrectValue(string candidate, bool expected)
        {
            var actual = AddressTrainer.AddressVector.ContainsStateAbbrev(candidate); 

            Assert.Equal(expected, actual); 
        }

        
        

    }
} 
