using Data;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

namespace CustomBeatmapMaker.Action
{
    public abstract class Action
    {
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
        public abstract override string ToString();
    }

    public abstract class SingleAction : Action
    {
        public SingleAction Inverse;
        protected NoteData _data;
        
        public abstract SingleAction CreateInverse();
    }

    public abstract class MultiAction : Action
    {
        public MultiAction Inverse;
        protected List<SingleAction> _singleActions;

        public MultiAction() { }
        public MultiAction(List<SingleAction> singleActions)
        {
            _singleActions = singleActions;
            Inverse = CreateInverse();
        }

        public MultiAction CreateInverse()
        {
            List<SingleAction> inverseActions = new List<SingleAction>();

            foreach (SingleAction action in _singleActions)
            {
                inverseActions.Add(action.CreateInverse());
            }

            return new DeleteNotes(inverseActions);
        }
    }
}