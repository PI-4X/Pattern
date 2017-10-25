using SplitMap.Animal.Adapter;
using SplitMap.Animal.Base;
using SplitMap.Animal.Facade;
using System.Collections.Generic;

namespace SplitMap.Animal.Bridge
{
    public interface TravelSecurity
    {      
        void Step(Dictionary<BaseAnimal, List<int>> TravelWay ,BaseAnimal animal, FieldMap fieldMapCurrent, List<FieldMap> PictureControls, KindStep kindStep);
        int ArrowAction(CrossBreeding crossBreeding);
    }
}
