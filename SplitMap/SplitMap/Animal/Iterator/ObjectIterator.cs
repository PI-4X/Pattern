using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitMap.Animal.Iterator
{
    public class ObjectIterator<T> : IIterator<T> where T : class
    {
        private IAggregate<T> aggregate = null;
        private int currentIndex = 0;

        public ObjectIterator(IAggregate<T> newAggregate)
        {
            aggregate = newAggregate;
        }
        //Returns item with index 0
        public T FirstItem
        {
            get
            {
                currentIndex = 0;
                return aggregate[currentIndex];
            }
        }
        //Returns next item
        public T NextItem
        {
            get
            {
                currentIndex += 1;

                if (IsDone == false)
                    return aggregate[currentIndex];
                else
                    return default(T);
            }
        }
        public T CurrentItem
        {
            get
            {
                return aggregate[currentIndex];
            }
        }
        //This method will give us feedabck when iteration ended
        public bool IsDone
        {
            get
            {
                if (currentIndex < aggregate.Count)
                    return false;
                return true;
            }
        }
    }
}
