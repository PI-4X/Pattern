using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitMap.Animal.Iterator
{
    public class Aggregate<T> : IAggregate<T> where T : class
    {
        List<T> values;
        public Aggregate()
        {
            values = new List<T>();
        }
        public IIterator<T> GetIterator()
        {
            //Iterator constructor takes IAggregate as parameter
            return new ObjectIterator<T>(this);
        }

        public void SetCollection(IEnumerable<T> collection)
        {
            values = new List<T>(collection);
        }

        public T this[int itemIndex]
        {
            get
            {
                if (itemIndex < values.Count)
                {
                    return values[itemIndex];
                }
                else
                {
                    return default(T);
                }
            }
            set
            {
                values.Add(value);
            }
        }
        public int Count
        {
            get
            {
                return values.Count;
            }
        }
    }
}
