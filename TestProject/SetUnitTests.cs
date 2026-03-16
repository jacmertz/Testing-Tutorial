using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class SetUnitTests
    {
        //could test when create empty set that count is correct
        //and contains no items

        //and could similarly test the other constructor

        [Theory]
        [InlineData(new int[] { }, new int[] { }, new int[] { })]
        [InlineData(new int[] { }, new int[] {1,2}, new int[] {1,2})]
        [InlineData(new int[] {1,2}, new int[] { }, new int[] {1,2})]
        [InlineData(new int[] {1,2}, new int[] {3,4}, new int[] {1,2,3,4})]
        [InlineData(new int[] {1,2,3}, new int[] {2,3,4}, new int[] {1,2,3,4})]
        [InlineData(new int[] {1,2,3,4}, new int[] {1,2,3,4}, new int[] {1,2,3,4})]
        public void SetUnionIsCorrent(int[] set1Elems, int[] set2Elems, int[] expectedUnion)
        {
            Set set1 = new Set(set1Elems);
            Set set2 = new Set(set2Elems);

            Set actualUnion = set1.Union(set2);

            //make sure every value in expectedUnion is also actualUnion
            /*
            foreach(int num in expectedUnion)
            {
                Assert.Contains(num, actualUnion);
            }
            */

            Assert.All(expectedUnion, num => Assert.Contains(num, actualUnion));

            //check that counts are the same to make sure actualUnion doesn't contain
            //any extra elements
            Assert.Equal(expectedUnion.Length, actualUnion.Count);
        }

        [Theory]
        [InlineData(new int[] { }, new int[] { }, new int[] { })]
        [InlineData(new int[] { }, new int[] { 1, 2 }, new int[] {  })]
        [InlineData(new int[] { 1, 2 }, new int[] { }, new int[] {  })]
        [InlineData(new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { })]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 2, 3, 4 }, new int[] { 2, 3 })]
        [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        public void SetIntersectionIsCorrent(int[] set1Elems, int[] set2Elems, int[] expectedIntersection)
        {
            Set set1 = new Set(set1Elems);
            Set set2 = new Set(set2Elems);

            Set actualIntersection = set1.Intersection(set2);

            Assert.All(expectedIntersection, num => Assert.Contains(num, actualIntersection));
            Assert.Equal(expectedIntersection.Length, actualIntersection.Count);
        }
    }
}
