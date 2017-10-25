using SplitMap.Animal.Base;
using SplitMap.Animal.Iterator;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SplitMap.Animal.Composite
{
    public class MapComposite : BaseObject, IMapComposite
    {
        #region Private field
        private Aggregate<IMapComponent> aggregator;
        private IIterator<IMapComponent> iterator;
        private List<IMapComponent> _components = new List<IMapComponent>();
        #endregion
        #region Public method
        public void AddComponent(IMapComponent component)
        {
            this._components.Add(component);
            component.Parent = this;
            aggregator = new Aggregate<IMapComponent>();
        }
        public override IMapComponent FindChild(Guid name)
        {
            if (this.GetGuid == name)
            {
                return this;
            }

            foreach (IMapComponent component in this._components)
            {
                IMapComponent found = component.FindChild(name);

                if (found != null)
                {
                    return found;
                }
            }

            return null;
        }
        public override void DrawCompositeObject()
        {
            aggregator.SetCollection(_components);
            iterator = aggregator.GetIterator();
            for (var item = iterator.FirstItem; iterator.IsDone == false; item = iterator.NextItem)
            {
                if (item is BaseAnimal)
                {
                    var monkey = (item as BaseAnimal);
                    monkey.DrawObject();
                }
                else
                    item.DrawCompositeObject();
                   
            }
        }
        public IEnumerable<IMapComponent> Generator()
        {
            aggregator.SetCollection(_components);
            iterator = aggregator.GetIterator();
            for (var item = iterator.FirstItem; iterator.IsDone == false; item = iterator.NextItem)
            {
                yield return item;
            }
        } 
        #endregion

    }
}
