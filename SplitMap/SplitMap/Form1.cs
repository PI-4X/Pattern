using SplitMap.Animal.Action;
using SplitMap.Animal.Base;
using SplitMap.Animal.BridgeDraw;
using SplitMap.Animal.Composite;
using SplitMap.Animal.Decorator;
using SplitMap.Animal.Derived;
using SplitMap.Animal.Facade;
using SplitMap.Animal.Flyweight;
using SplitMap.Animal.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
namespace SplitMap
{
    public partial class Form1 : Form
    {

        List<BaseAnimal> Zoo;
        object locker;
        List<FieldMap> PictureControls;
        CancellationTokenSource TokenSource;
        CancellationToken Token;
        TaskScheduler Context;
        List<AstarParamether> list;
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        Color PreviosColor = Color.Transparent;
        int indexBar = 0;
        BaseAction MainGroup;
        ConstructMap constructMap;
        Random RandomAction;

        public Form1()
        {
            InitializeComponent();
            //player.URL = "John.mp3";
            //player.controls.play();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            RandomAction = new Random();
            locker = new object();
            TokenSource = new CancellationTokenSource();
            Token = TokenSource.Token;
            Context = TaskScheduler.FromCurrentSynchronizationContext();
            Zoo = new List<BaseAnimal>();
            list = new List<AstarParamether>();

            PictureControls = new List<FieldMap>();
            constructMap = new ConstructMap(PictureControls);


        }

        private async void button1_Click(object sender, EventArgs e)
        {


            //foreach (var item in MainGroup.Generator())
            //{
            //    var animal = (item as BaseAnimal);
            //    var sp = new SearchParameters(new Point(animal.Coordinate.Y, animal.Coordinate.X), new Point(7, 15));
            //    list.Add(new AstarParamether() { searchParameters = sp, Token = Token, StartCoordinate = animal.Coordinate, Animal = animal, Path = new List<Point>() });
            //}

            //#region Parallel          

            //Parallel.ForEach(list, item =>
            //{
            //    Astar(item);
            //});

            //#endregion



        }


        //public Task Astar(AstarParamether paramether)
        //{
        //    return Task.Factory.StartNew(async () =>
        //    {
        //        List<Point> path = new List<Point>();
        //        lock (locker)
        //        {

        //            PathFinder pathFinder = new PathFinder(paramether.searchParameters, paramether.Animal);
        //            path = new List<Point>();
        //            path = pathFinder.FindPath();
        //            paramether.searchParameters.UpdateNode(path[0].X, path[0].Y, false);
        //        }
        //        if (path.Count == 1)
        //        {
        //            await DrawAnimal(path[0], paramether.StartCoordinate, paramether.Animal);
        //            lock (locker)
        //            {
        //                var bananas = constructMap.ActionList.Where(item => (item as BaseAction).baseDescribeAction.GetNameAction == "Banana"
        //                && (item as BaseAction).Coordinate == path[0]).SingleOrDefault();
        //                constructMap.ActionList.Remove(bananas);
        //            }
        //            return;
        //        }
        //        else
        //        {
        //            await Task.Delay(1000);
        //            lock (locker)
        //            {
        //                DrawAnimal(path[0], paramether.StartCoordinate, paramether.Animal);
        //                paramether.Path.Add(new Point(path[0].X, path[0].Y));
        //                paramether.searchParameters.UpdateNode(paramether.StartCoordinate.X, paramether.StartCoordinate.Y, true);
        //                paramether.searchParameters.StartLocation = new Point(path[0].X, path[0].Y);
        //            }

        //            await Astar(paramether);

        //        }
        //    }, Token, TaskCreationOptions.LongRunning, Context);
        //}

        //public Task DrawAnimal(Point current, Point last, BaseAnimal animal)
        //{
        //    int index = 0;
        //    index = current.X + (current.Y * 10);
        //    return Task.Factory.StartNew(() =>
        //   {
        //       lock (locker)
        //       {
        //           if (Token.IsCancellationRequested)
        //               Token.ThrowIfCancellationRequested();
        //           var indexlast = last.X + (last.Y * 10);
        //           animal.DestroyObject();
        //           animal.pictureBox = PictureControls[index].PictureBox;
        //           return animal;
        //       }
        //   }, Token, TaskCreationOptions.RunContinuationsAsynchronously, Context).ContinueWith(async t =>
        //   {
        //       var result = await t;
        //       await Task.Yield();
        //       result.DrawObject();
        //   }, Token, TaskContinuationOptions.AttachedToParent, Context);
        //}

        #region Waiting
        private void buttonDrawMap_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
            constructMap.ActionList.Clear();
            list.Clear();
            PictureControls.Clear();
            panelMain.Controls.Clear();
            panelMain.Invalidate();
            CreateMap();
        }

        private void buttonDrawAbility_Click(object sender, EventArgs e)
        {
            var task = Task.Factory.StartNew(() =>
            {
                foreach (var item in Zoo)
                    item.DrawAbilities();

            }, Token, TaskCreationOptions.None, Context);

        }

        private async void buttonCreateAnimal_Click(object sender, EventArgs e)
        {
            try
            {
                var y = trackBar1.Value / 10;
                var x = trackBar1.Value % 10;
                var animal = await constructMap.CreateAnimal(KindAnimal.Monkey, x, y);
                await (animal as ICanLearnAction).LearningActionAsync(new WalkFieldAction().GetType(), "Walk on field");
                await (animal as ICanLearnAction).LearningActionAsync(new EatBananaAction().GetType(), "Eat banana");
                await (animal as ICanLearnAction).LearningActionAsync(new ProxyClimbToRockAction().GetType(), "Proxy climb to rock");
                animal.DrawObject();
                Zoo.Add(animal);

            }
            catch (FieldWasBusyException fe)
            {
                MessageBox.Show(fe.Message);
            }

        }

        private void CreateMap()
        {
            constructMap.CreateMap(panelMain);
            PreviosColor = PictureControls[0].PictureBox.BackColor;
        }

        private void buttonDrawActionAbility_Click(object sender, EventArgs e)
        {
            var task = Task.Factory.StartNew(() =>
            {
                foreach (var item in constructMap.ActionList)
                    item.DrawAbilities();

            }, Token, TaskCreationOptions.None, Context);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //PictureControls[indexBar].PictureBox.BackColor = PreviosColor;
            indexBar = trackBar1.Value;
            // PreviosColor = PictureControls[indexBar].PictureBox.BackColor;
            //PictureControls[indexBar].PictureBox.BackColor = Color.SandyBrown;

        }

        private void buttonUp_Click(object sender, EventArgs e)
        {

            foreach (var item in Zoo)
            {
                item.DoStep(KindStep.Up, PictureControls);
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            foreach (var item in Zoo)
            {
                item.DoStep(KindStep.Down, PictureControls);
            }
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            foreach (var item in Zoo)
            {
                item.DoStep(KindStep.Left, PictureControls);
            }
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            foreach (var item in Zoo)
            {
                item.DoStep(KindStep.Right, PictureControls);
            }
        }

        private void buttonActionDecorator_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            var index = rand.Next(0, 199);
            var item = (constructMap.ActionList.SingleOrDefault(x => (x as BaseAction).IndexBlock == index) as BaseAction);
            switch (rand.Next(0, 2))
            {
                case 0:
                    {
                        item = new RedActionDecorator(item);
                        break;
                    }
                case 1:
                    {
                        item = new BlueActionDecorator(item);
                        break;
                    }
                default:
                    break;
            }


        }

        private async void buttonCreateAction_Click(object sender, EventArgs e)
        {
            var y = trackBar1.Value / 10;
            var x = trackBar1.Value % 10;
            try
            {
                switch (RandomAction.Next(0, 3))
                {
                    case 0:
                        {
                            await constructMap.CreateAction(KindAction.Climb, x, y);
                            break;
                        }
                    case 1:
                        {
                            await constructMap.CreateAction(KindAction.Banana, x, y);
                            break;
                        }
                    case 2:
                        {
                            await constructMap.CreateAction(KindAction.ProxyClimb, x, y);
                            break;
                        }
                    case 3:
                        {
                            await constructMap.CreateAction(KindAction.WalkField, x, y);
                            break;
                        }
                    default: break;

                }
            }
            catch (FieldWasBusyException fe)
            {
                MessageBox.Show(fe.Message);
            }

        }

        #endregion

        private void buttonAddComponent_Click(object sender, EventArgs e)
        {
            var y = trackBar1.Value / 10;
            var x = trackBar1.Value % 10;


            var baseAction = new ClimbToRockAction()
            {
                pictureBox = PictureControls[x + (y * 10)].PictureBox,
                baseDescribeAction = BaseDescribeFactory.Instance.GetDescribe(KindAction.Climb)
            };
            MainGroup = new ZooComposite(baseAction);



            var bananabaseAction = new EatBananaAction()
            {
                pictureBox = PictureControls[x + (y * 10)].PictureBox,
                baseDescribeAction = BaseDescribeFactory.Instance.GetDescribe(KindAction.Banana)
            };




            MainGroup.AddAction(bananabaseAction);
            MainGroup.AddAction(bananabaseAction);
            MainGroup.DrawObject();

        }
    }
    public enum KindStep
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3,
    }
    public enum KindAction
    {
        WalkField = 0,
        Banana = 1,
        Climb = 2,
        ProxyClimb = 3,
        Arrow = 4,
    }
    public enum KindAnimal
    {
        Monkey = 0,
    }
    public class AstarParamether
    {
        public SearchParameters searchParameters { get; set; }
        public CancellationToken Token { get; set; }
        public Point StartCoordinate { get; set; }
        public BaseAnimal Animal { get; set; }
        public List<Point> Path { get; set; }
    }


}
