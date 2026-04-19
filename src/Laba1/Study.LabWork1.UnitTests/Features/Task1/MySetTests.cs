using System;
using System.Collections.Generic;
using System.Text;
using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.UnitTests.Features.Task1
{
    [TestFixture]
    internal class MySetTests
    {
        [Test]
        public void UniqueElements()
        {
            var input = new[] { 1, 2, 2, 3, 3, 3, 4 };
            
            var set = new MySet<int>(input);
            
            Assert.That(set.Count, Is.EqualTo(4)); // 1, 2, 3, 4
            Assert.That(set.ToString(), Is.EqualTo("{1, 2, 3, 4}"));
        }

        [Test]
        public void Union()
        {
            var set1 = new MySet<int>([ 1, 2, 3 ]);
            var set2 = new MySet<int>([ 3, 4, 5 ]);
     
            var result = set1 | set2;
  
            Assert.That(result.Count, Is.EqualTo(5)); // 1, 2, 3, 4, 5
            Assert.That(result.ToString(), Is.EqualTo("{1, 2, 3, 4, 5}"));
        }
        [Test]
        public void Intersect()
        {
            var set1 = new MySet<int>([1, 2, 3, 4]);
            var set2 = new MySet<int>([3, 4, 5, 6]);
            
            var result = set1 & set2;

            Assert.That(result.Count, Is.EqualTo(2)); // 3, 4
            Assert.That(result.ToString(), Is.EqualTo("{3, 4}"));
        }
        [Test]
        public void Difference()
        {
            var set1 = new MySet<int>([1, 2, 3, 4]);
            var set2 = new MySet<int>([3, 4, 5, 6]);

            var result = set1 - set2;

            Assert.That(result.Count, Is.EqualTo(2)); // 1, 2
            Assert.That(result.ToString(), Is.EqualTo("{1, 2}"));
        }

        [Test]
        public void SymmetricDifference()
        {
            var set1 = new MySet<int>([1, 2, 3, 4]);
            var set2 = new MySet<int>([3, 4, 5, 6]);

            var result = set1 / set2;
            
            Assert.That(result.Count, Is.EqualTo(4)); // 1, 2, 5, 6
            Assert.That(result.ToString(), Is.EqualTo("{1, 2, 5, 6}"));
        }

        [Test]
        public void Equality()
        {
            var set1 = new MySet<int>([1, 2, 3]);
            var set2 = new MySet<int>([1, 2, 3]);

            Assert.That(set1 == set2, Is.True);
            Assert.That(set1 != set2, Is.False);
            Assert.That(set1.Equals(set2), Is.True);
        }
    }
}
