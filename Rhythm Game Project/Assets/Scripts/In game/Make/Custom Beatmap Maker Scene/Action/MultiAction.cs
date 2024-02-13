using System.Collections.Generic;

namespace CustomBeatmapMaker.Action
{
    public abstract class MultiAction : Action
    {
        protected List<SingleAction> _singleActions;

        public MultiAction() { }
        public MultiAction(List<SingleAction> singleActions)
        {
            _singleActions = singleActions;
            Inverse = CreateInverse();
        }
        
        public List<SingleAction> GetSingleActionInverses()
        {
            List<SingleAction> inverseActions = new List<SingleAction>();
            foreach (SingleAction action in _singleActions) inverseActions.Add(action.CreateInverse() as SingleAction);
            return inverseActions;
        }
        public override void Perform()
        {
            foreach (SingleAction singleAction in _singleActions) singleAction.Perform();
        }
    }
}