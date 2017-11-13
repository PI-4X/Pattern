using SplitMap.Animal.Action;
using SplitMap.Animal.Adapter;
using SplitMap.Animal.Base;
using SplitMap.Animal.BridgeDraw;
using SplitMap.Animal.Derived;
using SplitMap.Animal.Flyweight;
using SplitMap.Animal.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitMap.Animal.Facade
{
    public class ConstructMap : IFacade
    {
        int H;
        int W;
        bool[,] Map;
        private readonly ActionConstructor actionConstructor =  new ActionConstructor();
        private readonly AnimalConstructor animalConstructor = new AnimalConstructor();
        private List<FieldMap> PictureControls { get; set; }
        public BaseAction[,] Typemap { get; }
        public List<BaseAction> ActionList { get; }
        public ConstructMap(List<FieldMap> CollectionControls, int Height = 10, int Width = 20)
        {
            H = Height;
            W = Width;
            Typemap = new BaseAction[H, W];
            ActionList = new List<BaseAction>();
            Map = new bool[H, W];
            PictureControls = CollectionControls;
        }
        public ConstructMap(int Height = 10, int Width = 20)
        {
            H = (Console.BufferHeight / 12) - 1;
            W = Console.BufferWidth;
            Typemap = new BaseAction[H, W];
            ActionList = new List<BaseAction>();
            Map = new bool[H, W];

        }
        public void CreateMap(Panel control)
        {
            var height = control.Size.Height;
            var width = control.Size.Width;
            int r = 0;
            int c = 0;
            int counter = 0;
            for (int i = 0; i < width; i += 50)
            {
                for (int j = 0; j < height; j += 50)
                {
                    PictureBox pb = new PictureBox
                    {
                        Parent = control,
                        Dock = DockStyle.None,
                        BackColor = Color.Transparent,
                        BorderStyle = BorderStyle.FixedSingle,
                        Size = new Size(50, 50),
                        Location = new Point(i, j),
                        BackgroundImageLayout = ImageLayout.Zoom,
                        Visible = true,
                        Name = $"Box{(i + 1) * (j + 1)}"
                    };
                    control.Controls.Add(pb);
                    PictureControls.Add(new FieldMap() { PictureBox = pb, Type = 0 });
                    Map[c, r] = true;
                    var item = new WalkFieldAction() { pictureBox =  PictureControls[counter].PictureBox,
                        baseDescribeAction = BaseDescribeFactory.Instance.GetDescribe(KindAction.WalkField) };
                    ActionList.Add(item);
                    Typemap[c, r] = item;
                    counter++;
                    c++;
                }
                c = 0;
                r++;
            }                    
            SearchParameters.InitilizeMap(Map, Typemap);
        }
        public void CreateMap()
        {
            var height = (Console.BufferHeight / 12) - 1;
            var width = Console.BufferWidth;
            int ch = 0;
            int r = 0;
            int c = 0;
            int counter = 0;

            for (int i = 0; i < height; i++)
            {
                int cw = 0;
                for (int j = 0; j < width; j++)
                {
                    if (ch % 2 != 0)
                    {
                        if (cw == 1)
                        {
                            Containers.Add("|");
                            cw = 0;
                        }
                        else
                        {
                            Containers.Add("_");
                            cw++;
                        }
                        continue;
                    }
                    if (cw == 1)
                    {
                        Containers.Add("|");
                        cw = 0;
                    }
                    else
                    {
                        Containers.Add(" ");
                        Map[c, r] = true;
                        var item = new WalkFieldAction()
                        {                           
                            baseDescribeAction = BaseDescribeFactory.Instance.GetDescribe(KindAction.WalkField)
                        };
                        ActionList.Add(item);
                        Typemap[c, r] = item;
                        counter++;
                        cw++;
                    }
                }
                c = 0;
                r++;
                ch++;
            }
        }
        public async Task CreateAction(KindAction kindAction, int x, int y)
        {
            int index = x + (y * H);
            var action = await actionConstructor.Create(kindAction, PictureControls[index]);
            ActionList[index] = action;
            Typemap[x, y] = action;
            if (action.baseDescribeAction.GetNameAction == "Banana" || action.baseDescribeAction.GetNameAction == "Field")
                SearchParameters.Map[x, y] = true;
            else
                SearchParameters.Map[x, y] = false;

            action.DrawObject();
        }
        
        public async Task<BaseAnimal> CreateAnimal(KindAnimal kindAnimal, int x, int y)
        {
            int index = x + (y * H);
            var animal = await animalConstructor.Create(kindAnimal, PictureControls[index]);
            SearchParameters.Map[x, y] = false;
            return animal;
        }


        public  BaseAnimal CreateAnimalConsole(KindAnimal kindAnimal, int x, int y)
        {
            var _x = x == 0 ? 0 : --x;
            var _y = y == 0 ? 0 : --y;
            var animal =  animalConstructor.CreateSync(kindAnimal, new FieldMap());
            animal.ConsolePoint = new Point(_y , _x);
            return animal;
        }
        public  void CreateActionConsole(KindAction kindAction, int x, int y)
        {
            int _x = x / 2;
            int _y = y / 2;
            int index = (_y  * 40 )+ (_x);
            var action =  actionConstructor.CreateSync(kindAction, new FieldMap());
             _x = x == 0 ? 0 : --x;
             _y = y == 0 ? 0 : --y;
            action.ConsolePoint = new Point(_y, _x);
            ActionList[index] = action;
            Typemap[y, x] = action;
            action.DrawObject();
        }


    }
    internal class AnimalConstructor
    {
        public async Task<BaseAnimal> Create(KindAnimal kindAnimal, FieldMap fieldMap)
        {
            Random rand = new Random();
            if (CheckField(fieldMap))
            {
                fieldMap.Type = 1;
                BaseAnimal monkey = null;
                switch (kindAnimal)
                {
                    case KindAnimal.Monkey:
                        {
                            monkey = new Monkey(){ pictureBox = fieldMap.PictureBox };
                            var task = Task.Factory.StartNew(async () =>
                            {
                                await monkey.AddCharacteristic("Age", rand.Next(0, 12).ToString());
                                await monkey.AddCharacteristic("Kind", "Monkey");
                                await monkey.AddCharacteristic("Name", "Baboo");
                            });
                            await task;
                            break;
                        }
                }
                return monkey;
            }
            else
                throw new FieldWasBusyException("Field is busing");
        }

        public  BaseAnimal CreateSync(KindAnimal kindAnimal, FieldMap fieldMap)
        {
            Random rand = new Random();
            if (CheckField(fieldMap))
            {
                fieldMap.Type = 1;
                BaseAnimal monkey = null;
                switch (kindAnimal)
                {
                    case KindAnimal.Monkey:
                        {
                            monkey = new Monkey() { pictureBox = fieldMap.PictureBox };
                           
                                 monkey.AddCharacteristicSync("Age", rand.Next(0, 12).ToString());
                                 monkey.AddCharacteristicSync("Kind", "Monkey");
                                 monkey.AddCharacteristicSync("Name", "Baboo");
                           
                            break;
                        }
                }
                return monkey;
            }
            else
                throw new FieldWasBusyException("Field is busing");
        }
    

        private bool CheckField(FieldMap fieldMap)
        {
            return fieldMap.Type == 0;
        }

    }
    internal class ActionConstructor
    {
        public async Task<BaseAction> Create(KindAction kindAction, FieldMap fieldMap)
        {
            Random rand = new Random();
            if (CheckField(fieldMap))
            {
                if(kindAction != KindAction.WalkField)
                    fieldMap.Type = 1;
                BaseAction baseAction = null;
                switch (kindAction)
                {
                    case KindAction.WalkField:
                        {
                            baseAction = new WalkFieldAction()
                            {
                                pictureBox = fieldMap.PictureBox,
                                baseDescribeAction = BaseDescribeFactory.Instance.GetDescribe(kindAction)
                            };
                            break;
                        }
                    case KindAction.Banana:
                        {
                            baseAction = new EatBananaAction()
                            {
                                pictureBox = fieldMap.PictureBox,
                                baseDescribeAction = BaseDescribeFactory.Instance.GetDescribe(kindAction)
                            };
                           
                            break;
                        }
                    case KindAction.Climb:
                        {
                            baseAction = new ClimbToRockAction()
                            {
                                pictureBox = fieldMap.PictureBox,
                                baseDescribeAction = BaseDescribeFactory.Instance.GetDescribe(kindAction)
                            };
                            break;
                        }
                    case KindAction.ProxyClimb:
                        {
                            baseAction = new ProxyClimbToRockAction()
                            {
                                pictureBox = fieldMap.PictureBox,
                                baseDescribeAction = BaseDescribeFactory.Instance.GetDescribe(kindAction)
                            };
                            break;
                        }
                    case KindAction.Arrow:
                        {
                            var arrow = new ArrowSign
                            {
                                CurrentArrow = ArrowEnum.Down
                            };
                            baseAction = new CrossBreeding(arrow)
                            {
                                pictureBox = fieldMap.PictureBox,
                                baseDescribeAction = BaseDescribeFactory.Instance.GetDescribe(kindAction)
                            };
                            break;
                        }
                }
                return await Task.Factory.StartNew(() => baseAction);
            }
            else
                throw new FieldWasBusyException("Field is busing");
        }
        public  BaseAction CreateSync(KindAction kindAction, FieldMap fieldMap)
        {
            Random rand = new Random();
            if (CheckField(fieldMap))
            {
                if (kindAction != KindAction.WalkField)
                    fieldMap.Type = 1;
                BaseAction baseAction = null;
                switch (kindAction)
                {
                    case KindAction.WalkField:
                        {
                            baseAction = new WalkFieldAction()
                            {
                                pictureBox = fieldMap.PictureBox,
                                baseDescribeAction = BaseDescribeFactory.Instance.GetDescribe(kindAction)
                            };
                            break;
                        }
                    case KindAction.Banana:
                        {
                            baseAction = new EatBananaAction()
                            {
                                pictureBox = fieldMap.PictureBox,
                                baseDescribeAction = BaseDescribeFactory.Instance.GetDescribe(kindAction)
                            };

                            break;
                        }
                    case KindAction.Climb:
                        {
                            baseAction = new ClimbToRockAction()
                            {
                                pictureBox = fieldMap.PictureBox,
                                baseDescribeAction = BaseDescribeFactory.Instance.GetDescribe(kindAction)
                            };
                            break;
                        }
                    case KindAction.ProxyClimb:
                        {
                            baseAction = new ProxyClimbToRockAction()
                            {
                                pictureBox = fieldMap.PictureBox,
                                baseDescribeAction = BaseDescribeFactory.Instance.GetDescribe(kindAction)
                            };
                            break;
                        }
                    case KindAction.Arrow:
                        {
                            var arrow = new ArrowSign
                            {
                                CurrentArrow = ArrowEnum.Down
                            };
                            baseAction = new CrossBreeding(arrow)
                            {
                                pictureBox = fieldMap.PictureBox,
                                baseDescribeAction = BaseDescribeFactory.Instance.GetDescribe(kindAction)
                            };
                            break;
                        }
                }
                return baseAction;
            }
            else
                throw new FieldWasBusyException("Field is busing");
        }
        private bool CheckField(FieldMap fieldMap)
        {
            return fieldMap.Type == 0;
        }
    }

}
