using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingTutorial
{
    /// <summary>
    /// Represents a set of integers (with no duplicates)
    /// </summary>
    /// 

    //NOTE: this implementation has errors that will be corrected with testing

    public class Set : IEnumerable<int>
    {
        /// <summary>
        /// The elements in this set
        /// </summary>
        private HashSet<int> _elems = new HashSet<int>();

        /// <summary>
        /// The number of elements in this set
        /// </summary>
        public int Count => _elems.Count;

        /// <summary>
        /// Constructs a new set with the given elements
        /// </summary>
        /// <param name="nums">The initial elements to add to the set</param>
        public Set(int[] nums)
        {
            foreach (int num in nums)
            {
                _elems.Add(num);
            }
        }

        /// <summary>
        /// Constructs an empty set
        /// </summary>
        public Set()
        {

        }

        /// <summary>
        /// Adds a new element to this set
        /// </summary>
        /// <param name="num">The number to add</param>
        public void Add(int num)
        {
            _elems.Add(num);
        }

        /// <summary>
        /// Finds the union between this set and another set
        /// </summary>
        /// <param name="set">The other set</param>
        /// <returns>The union between this set and <paramref name="set"/></returns>
        public Set Union(Set set)
        {
            Set union = new Set();

            foreach (int num in _elems)
            {
                union.Add(num);
            }
            foreach (int num in set._elems)
            {
                union.Add(num);
            }

            return union;
        }

        /// <summary>
        /// Finds the intersection between this set and another set
        /// </summary>
        /// <param name="set">The other set</param>
        /// <returns>The intersection between this set and <paramref name="set"/></returns>
        public Set Intersection(Set set)
        {
            Set intersection = new Set();

            foreach(int num in _elems)
            {
                if (set._elems.Contains(num))
                {
                    intersection.Add(num);
                }
            }

            return intersection;
        }

        /// <summary>
        /// Gets an enumerator for this set
        /// </summary>
        /// <returns>An enumerator for this set</returns>
        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>)_elems).GetEnumerator();
        }

        /// <summary>
        /// Gets an enumerator for this set (a non-generics version)
        /// </summary>
        /// <returns>An enumerator for this set</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_elems).GetEnumerator();
        }
    }
}
