using SplitMap.Animal.Adapter;
using SplitMap.Animal.Base;
using SplitMap.Animal.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitMap.Animal.Bridge
{
    public abstract class TravelMaster
    {
        protected Dictionary<BaseAnimal, List<int>> TravelWay;
        protected TravelSecurity travelSecurity;
        public TravelSecurity Security
        {
            set { travelSecurity = value; }
        }
        public TravelMaster(TravelSecurity security)
        {
            travelSecurity = security;
            TravelWay = new Dictionary<BaseAnimal, List<int>>();
        }
        public virtual void RemoveWay(BaseAnimal animal)
        {
            if (TravelWay.ContainsKey(animal))
                TravelWay[animal].Clear();
        }
        public virtual List<int> GetWay(BaseAnimal animal)
        {
            if (TravelWay.ContainsKey(animal))
                return TravelWay[animal];
            return new List<int>();
        }
        public virtual int LengthPath(BaseAnimal animal)
        {
            if (TravelWay.ContainsKey(animal))
                return TravelWay[animal].Count;
            return 0;
        }

        public virtual void DoStep(BaseAnimal animal, FieldMap fieldMapCurrent, List<FieldMap> PictureControls, KindStep kindStep)
        {
            travelSecurity.Step(TravelWay, animal, fieldMapCurrent, PictureControls, kindStep);
        }
    }
}
