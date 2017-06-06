using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aibio.Units.Sensors;
using NUnit.Framework;

namespace aibio.Test
{
    [TestFixture]
    public class OrganismTests
    {
        [Test]
        public void InitializeOrganism()
        {
            Organism testOrganism = new Organism(null, null, 40);
            Assert.IsNotNull(testOrganism);
        }
    }
}
