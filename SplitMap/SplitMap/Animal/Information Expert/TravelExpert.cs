using SplitMap.Animal.Adapter;
using SplitMap.Animal.Base;
using SplitMap.Animal.Bridge;
using SplitMap.Animal.Facade;
using SplitMap.Animal.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitMap.Animal.Information_Expert
{
    public class TravelExpert : TravelMaster
    {
        public TravelExpert(TravelSecurity security) : base(security)
        {}
        public override int LengthPath(BaseAnimal animal)
        {
            return base.LengthPath(animal) - 1;
        }
    }
}
