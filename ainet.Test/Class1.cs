﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ainet.Test
{
    [TestFixture]
    public class BasicNetTests
    {
        [Test]
        public void NetworkInit()
        {
            Network testNet = new Network(2, 2, 8);
            testNet.Reinforce(new double[] { 1, 0 }, new double[] { 0, 1 });
            testNet.Reinforce(new double[] { 0, 1 }, new double[] { 1, 0 });
            double[] result = testNet.Decide(new double[] {0, 1});
            Assert.That(result[0], Is.AtLeast(0.5f));
            Assert.That(result[0], Is.LessThanOrEqualTo(1.0f));
            Assert.That(result[1], Is.AtLeast(0.0f));
            Assert.That(result[1], Is.LessThan(0.5f));
        }

        [Test]
        public void NetworkReinforce()
        {
            Network testNet = new Network(2, 2, 8);
            testNet.Reinforce(new double[] { 1, 0 }, new double[] { 0, 1 });
            testNet.Reinforce(new double[] { 0, 1 }, new double[] { 1, 0 });
        }

        [Test]
        [Ignore("Underlying bug in Accord Framework.")]
        public void NetworkReinforce2()
        {
            Network testNet = new Network(2, 2, 8);
            testNet.Reinforce(new double[] { 1, 0 }, new double[] { 0, 1 });
            testNet.Reinforce(new double[] { 0, 1 }, new double[] { 1, 0 });
            testNet.Decide(new double[] { 0, 1 });
            testNet.Reinforce(new double[] { 0, 1 });
            double[] result = testNet.Decide(new double[] { 0, 1 });
            Assert.That(result[0], Is.AtLeast(0.5f));
            Assert.That(result[0], Is.LessThanOrEqualTo(1.0f));
            Assert.That(result[1], Is.AtLeast(0.0f));
            Assert.That(result[1], Is.LessThan(0.5f));
        }

        [Test]
        public void NetworkDecide()
        {
            Network testNet = new Network(2, 2, 8);
            testNet.Reinforce(new double[] { 1, 0 }, new double[] { 0, 1 });
            testNet.Reinforce(new double[] { 0, 1 }, new double[] { 1, 0 });
            double[] result = testNet.Decide(new double[] { 0, 1 });
            Assert.That(result[0], Is.AtLeast(0.5f));
            Assert.That(result[0], Is.LessThanOrEqualTo(1.0f));
            Assert.That(result[1], Is.AtLeast(0.0f));
            Assert.That(result[1], Is.LessThan(0.5f));
        }
    }
}
