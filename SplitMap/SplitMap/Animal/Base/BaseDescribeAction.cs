using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitMap.Animal.Base
{
    public abstract class BaseDescribeAction
    {
        /// <summary>
        /// Action name
        /// </summary>
        public virtual string GetNameAction { get; } = "None";
        /// <summary>
        /// Level of difficulty of action
        /// </summary>
        public virtual LevelAction GetLevelAction { get; } = LevelAction.Easy;

        public virtual Bitmap Sprite { get;}
    }
    public class EatBananaDescribeAction : BaseDescribeAction
    {
        public override string GetNameAction => "Banana";

        public override LevelAction GetLevelAction => LevelAction.Easy;

        public override Bitmap Sprite { get; } = new Bitmap(Properties.Resources.banana, new Size(22,22));

    }
    public class WalkFieldDescribeAction : BaseDescribeAction
    {
        public override string GetNameAction => "Field";

        public override LevelAction GetLevelAction => LevelAction.Easy;

    }
    public class ArrowDescribeAction : BaseDescribeAction
    {
        public override string GetNameAction => "Arrow";

        public override LevelAction GetLevelAction => LevelAction.Easy;

    }
    public class ClimbToRockDescribeAction : BaseDescribeAction
    {
        public override string GetNameAction => "Rock";

        public override LevelAction GetLevelAction => LevelAction.Hard;

        public override Bitmap Sprite { get; } = new Bitmap(Properties.Resources.rock, new Size(45, 45));
    }
    public class ProxyClimbToRockDescribeAction : BaseDescribeAction
    {
        public override string GetNameAction => "Save Rock";

        public override LevelAction GetLevelAction => LevelAction.Medium;

        public override Bitmap Sprite { get; } = new Bitmap(Properties.Resources.safetyRock, new Size(45, 45));
    }
}
