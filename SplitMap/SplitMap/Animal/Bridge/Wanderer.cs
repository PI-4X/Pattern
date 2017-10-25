using System;
using System.Collections.Generic;
using SplitMap.Animal.Adapter;
using SplitMap.Animal.Base;
using SplitMap.Animal.Facade;
using SplitMap.Animal.Interface;

namespace SplitMap.Animal.Bridge
{
    public class Wanderer : TravelSecurity
    {
        public void Step(Dictionary<BaseAnimal, List<int>> TravelWay, BaseAnimal animal, FieldMap fieldMapCurrent, 
            List<FieldMap> PictureControls, KindStep kindStep)
        {
            int x = 0;
            int y = 0;
            int sub = 0;
            switch (kindStep)
            {
                case KindStep.Up:
                    {
                        x = animal.Coordinate.X;
                        y = animal.Coordinate.Y - 1;
                        sub = -1;
                        break;
                    }
                case KindStep.Down:
                    {
                        x = animal.Coordinate.X;
                        y = animal.Coordinate.Y + 1;
                        sub = 1;
                        break;
                    }
                case KindStep.Left:
                    {
                        x = animal.Coordinate.X - 1;
                        y = animal.Coordinate.Y;
                        sub = -10;
                        break;
                    }
                case KindStep.Right:
                    {
                        x = animal.Coordinate.X + 1;
                        y = animal.Coordinate.Y;
                        sub = 10;
                        break;
                    }
            }

            if ((x < 20 && x >= 0) && (y < 10 && y >= 0))
            {
                if (SearchParameters.TypesMap[y, x].GetType() == typeof(CrossBreeding))
                {
                    var _index = ArrowAction(SearchParameters.TypesMap[y, x] as CrossBreeding);
                    animal.DestroyObject();
                    fieldMapCurrent.Type = 0;
                    if (!TravelWay.ContainsKey(animal))
                        TravelWay.Add(animal, new List<int>());
                    TravelWay[animal].Add(animal.IndexBlock);
                    TravelWay[animal].Add(animal.IndexBlock + _index);
                    animal.pictureBox = PictureControls[animal.IndexBlock + _index + sub].PictureBox;
                    animal.DrawObject();
                    PictureControls[animal.IndexBlock].Type = 1;
                }
                else if ((animal as IDoAction).MakeAction(SearchParameters.TypesMap[y, x]) && PictureControls[animal.IndexBlock + sub].Type == 0)
                {
                    animal.DestroyObject();
                    fieldMapCurrent.Type = 0;
                    if (!TravelWay.ContainsKey(animal))
                        TravelWay.Add(animal, new List<int>());

                    TravelWay[animal].Add(animal.IndexBlock);
                    animal.pictureBox = PictureControls[animal.IndexBlock + sub].PictureBox;
                    animal.DrawObject();
                    PictureControls[animal.IndexBlock].Type = 1;
                }
            }
        }
        public int ArrowAction(CrossBreeding crossBreeding)
        {
            var _index = 0;
            switch (crossBreeding.Arrow.CurrentArrow)
            {
                case  Derived.ArrowEnum.Up:
                    {
                        _index = -1;
                        break;
                    }
                case Derived.ArrowEnum.Down:
                    {
                        _index = +1;
                        break;
                    }
                case Derived.ArrowEnum.Left:
                    {
                        _index = -10;
                        break;
                    }
                case Derived.ArrowEnum.Right:
                    {
                        _index = 10;
                        break;
                    }
            }

            return _index;
        }
    }
}
