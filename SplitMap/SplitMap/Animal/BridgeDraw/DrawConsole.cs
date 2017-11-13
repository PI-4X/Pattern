using SplitMap.Animal.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplitMap.Animal.Base;
using SplitMap.Animal.Adapter;

namespace SplitMap.Animal.BridgeDraw
{
    public class DrawConsole : IDrawMaster
    {
        public void DestroyObject(BaseObject baseObject)
        {
            throw new NotImplementedException();
        }

        public void DrawAbilities(BaseObject baseObject)
        {
            throw new NotImplementedException();
        }

        public void DrawObject(BaseObject baseObject)
        {
            if(baseObject is BaseAction)
            {
                var bAction = (baseObject as BaseAction);
                switch (bAction.baseDescribeAction.GetNameAction)
                {
                    case "Safe Rock":
                        {
                            Containers.Replace("&" ,bAction.ConsolePoint.X, bAction.ConsolePoint.Y);
                            break;
                        }
                    case "Rock":
                        {
                            Containers.Replace("@", bAction.ConsolePoint.X, bAction.ConsolePoint.Y);
                            break;
                        }
                    case "Field":
                        {
                            Containers.Replace(" ", bAction.ConsolePoint.X, bAction.ConsolePoint.Y);
                            break;
                        }
                    case "Banana":
                        {
                            Containers.Replace("B", bAction.ConsolePoint.X, bAction.ConsolePoint.Y);
                            break;
                        }
                    case "Arrow":
                        {
                            var arrow = (bAction as CrossBreeding);
                            string sign = string.Empty;
                            switch(arrow.Arrow.CurrentArrow)
                            {
                                case Derived.ArrowEnum.Down:
                                    {
                                        sign = "2";
                                        break;
                                    }
                                case Derived.ArrowEnum.Up:
                                    {
                                        sign = "8";
                                        break;
                                    }
                                case Derived.ArrowEnum.Left:
                                    {
                                        sign = "4";
                                        break;
                                    }
                                case Derived.ArrowEnum.Right:
                                    {
                                        sign = "6";
                                        break;
                                    }
                            }
                            Containers.Add(sign, bAction.ExternalCoordinate.X, bAction.ExternalCoordinate.Y);
                            break;
                        }
                }
            }
            else
            {
                var bAnimal = (baseObject as BaseAnimal);
                Containers.Replace("*", bAnimal.ConsolePoint.X, bAnimal.ConsolePoint.Y);
            }
        }
    }
}
