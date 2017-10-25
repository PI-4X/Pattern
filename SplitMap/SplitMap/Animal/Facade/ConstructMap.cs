using SplitMap.Animal.Action;
using SplitMap.Animal.Adapter;
using SplitMap.Animal.Base;
using SplitMap.Animal.BridgeObject;
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
        private BaseDescribeFactory mapComponentFactory;
        private readonly ActionConstructor actionConstructor =  new ActionConstructor();
        private readonly AnimalConstructor animalConstructor = new AnimalConstructor();
        private List<FieldMap> PictureControls { get; set; }
        public BaseAction[,] Typemap { get; }
        public List<BaseAction> ActionList { get; }
        private IDrawMaster drawActionMaster;
        private IDrawMaster drawAnimalMaster;
        public ConstructMap(List<FieldMap> CollectionControls, int Height = 10, int Width = 20)
        {
            H = Height;
            W = Width;
            Typemap = new BaseAction[H, W];
            ActionList = new List<BaseAction>();
            Map = new bool[H, W];
            PictureControls = CollectionControls;
            mapComponentFactory = BaseDescribeFactory.Instance;
            drawActionMaster = new DrawAction();
            drawAnimalMaster = new DrawAnimal();
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
                    var item = new WalkFieldAction(drawActionMaster) { pictureBox =  PictureControls[counter].PictureBox,
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
        public async Task CreateAction(KindAction kindAction, int x, int y)
        {
            int index = x + (y * H);
            var action = await actionConstructor.Create(kindAction, PictureControls[index], drawActionMaster);
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
            var animal = await animalConstructor.Create(kindAnimal, PictureControls[index], drawAnimalMaster);
            SearchParameters.Map[x, y] = false;
            return animal;
        }

       
    }
    internal class AnimalConstructor
    {
        public async Task<BaseAnimal> Create(KindAnimal kindAnimal, FieldMap fieldMap, IDrawMaster drawMaster)
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
                            monkey = new Monkey(drawMaster) { pictureBox = fieldMap.PictureBox };
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
        private bool CheckField(FieldMap fieldMap)
        {
            return fieldMap.Type == 0;
        }
    }
    internal class ActionConstructor
    {
        public async Task<BaseAction> Create(KindAction kindAction, FieldMap fieldMap, IDrawMaster drawMaster)
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
                            baseAction = new WalkFieldAction(drawMaster)
                            {
                                pictureBox = fieldMap.PictureBox,
                                baseDescribeAction = BaseDescribeFactory.Instance.GetDescribe(kindAction)
                            };
                            break;
                        }
                    case KindAction.Banana:
                        {
                            baseAction = new EatBananaAction(drawMaster)
                            {
                                pictureBox = fieldMap.PictureBox,
                                baseDescribeAction = BaseDescribeFactory.Instance.GetDescribe(kindAction)
                            };
                           
                            break;
                        }
                    case KindAction.Climb:
                        {
                            baseAction = new ClimbToRockAction(drawMaster)
                            {
                                pictureBox = fieldMap.PictureBox,
                                baseDescribeAction = BaseDescribeFactory.Instance.GetDescribe(kindAction)
                            };
                            break;
                        }
                    case KindAction.ProxyClimb:
                        {
                            baseAction = new ProxyClimbToRockAction(drawMaster)
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
                            baseAction = new CrossBreeding(drawMaster,arrow)
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
        private bool CheckField(FieldMap fieldMap)
        {
            return fieldMap.Type == 0;
        }
    }

}
