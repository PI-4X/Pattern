using System;
using System.Collections.Generic;

namespace SplitMap.Animal.Composite
{
    public interface IMapComponent
    {
        IMapComponent Parent { get; set; }
        IMapComponent FindChild(Guid name);
        void DrawCompositeObject();
    }
}
