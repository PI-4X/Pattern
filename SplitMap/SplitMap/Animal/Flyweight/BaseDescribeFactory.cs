using SplitMap.Animal.Base;
using System;
using System.Collections.Concurrent;


namespace SplitMap.Animal.Flyweight
{
    public class BaseDescribeFactory
    {
        private static readonly Lazy<BaseDescribeFactory> _instance  = new Lazy<BaseDescribeFactory>(() => new BaseDescribeFactory());
        private ConcurrentDictionary<KindAction, BaseDescribeAction> _actions  = new ConcurrentDictionary<KindAction, BaseDescribeAction>();
        private BaseDescribeFactory() {

            _actions.TryAdd(KindAction.WalkField , new WalkFieldDescribeAction());
            _actions.TryAdd(KindAction.Banana, new EatBananaDescribeAction());
            _actions.TryAdd(KindAction.ProxyClimb, new ProxyClimbToRockDescribeAction());
            _actions.TryAdd(KindAction.Climb, new ClimbToRockDescribeAction());
            _actions.TryAdd(KindAction.Arrow, new ArrowDescribeAction());
        }

        public static BaseDescribeFactory Instance
        {
            get { return BaseDescribeFactory._instance.Value; }
        }
        public BaseDescribeAction GetDescribe(KindAction treeType)
        {
            if (_actions.ContainsKey(treeType))
                return _actions[treeType];

            return null;
        }
    }
}
