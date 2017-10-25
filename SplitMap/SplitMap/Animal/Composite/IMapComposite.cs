using System;
using System.Collections.Generic;

namespace SplitMap.Animal.Composite
{
    public interface IMapComposite : IMapComponent
    {
        void AddComponent(IMapComponent component);
        IEnumerable<IMapComponent> Generator();
       
    }
}
