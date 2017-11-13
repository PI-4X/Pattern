using SplitMap.Animal.Action;
using SplitMap.Animal.Base;
using SplitMap.Animal.Facade;
using SplitMap.Animal.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitMap.Animal.BridgeDraw
{
    public class ConsoleGameManager
    {
        ConstructMap constructMap;
        List<BaseAnimal> Zoo;
        Random RandomAction;
        public ConsoleGameManager()
        {
            constructMap = new ConstructMap();
            Zoo = new List<BaseAnimal>();
            RandomAction = new Random();
        }
        public  void Start()
        {
            //y от нуля до 23
            //x от 0 до 79;
            constructMap.CreateMap();
            int x = 9;
            int y = 17;           
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Spacebar)
                {
                    var animal =  constructMap.CreateAnimalConsole(KindAnimal.Monkey, y, x);
                    (animal as ICanLearnAction).LearningAction(new WalkFieldAction().GetType(), "Walk on field");
                    (animal as ICanLearnAction).LearningAction(new EatBananaAction().GetType(), "Eat banana");
                    (animal as ICanLearnAction).LearningAction(new ProxyClimbToRockAction().GetType(), "Proxy climb to rock");
                    animal.DrawObject();
                    Zoo.Add(animal);
                }
                else if (key.Key == ConsoleKey.R)
                {
                    foreach(var item in Zoo)
                    {
                        item.DoStep(KindStep.Right);
                    }
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.I)
                {
                    y =  int.Parse(Console.ReadKey(true).KeyChar.ToString());
                    x = int.Parse(Console.ReadKey(true).KeyChar.ToString());
                    switch (RandomAction.Next(0, 3))
                    {
                        case 0:
                            {
                                 constructMap.CreateActionConsole(KindAction.Climb, x, y);
                                break;
                            }
                        case 1:
                            {
                                 constructMap.CreateActionConsole(KindAction.Banana, x, y);
                                break;
                            }
                        case 2:
                            {
                                 constructMap.CreateActionConsole(KindAction.ProxyClimb, x, y);
                                break;
                            }
                        case 3:
                            {
                                 constructMap.CreateActionConsole(KindAction.WalkField, x, y);
                                break;
                            }
                        default: break;

                    }
                }
            }
        }
    }
}
