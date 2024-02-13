using Data;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

namespace CustomBeatmapMaker.Action
{
    public abstract class Action
    {
        public Action Inverse;
        public static string Vector3ToXYOrderedPairString(Vector3 vector3)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("(");
            sb.Append(vector3.x);
            sb.Append(',');
            sb.Append(vector3.y);
            sb.Append(")");

            return sb.ToString();
        }

        public abstract void Perform();
        public abstract Action CreateInverse();
        public abstract override string ToString();
    }

    public abstract class SingleAction : Action
    {
        protected NoteData _data;
    }

    public abstract class MultiAction : Action
    {
        protected List<SingleAction> _singleActions;

        public MultiAction() { }
        public MultiAction(List<SingleAction> singleActions)
        {
            _singleActions = singleActions;
            Inverse = CreateInverse();
        }

        public override void Perform()
        {
            foreach (SingleAction singleAction in _singleActions) singleAction.Perform();
        }
    }
}