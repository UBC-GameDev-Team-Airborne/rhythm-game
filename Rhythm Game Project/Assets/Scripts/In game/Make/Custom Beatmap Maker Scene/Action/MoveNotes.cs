using Data;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace CustomBeatmapMaker.Action
{
    public class MoveNotes : MultiAction
    {
        private Vector3 _delta;

        public MoveNotes(List<NoteData> dataList, Vector3 delta)
        {
            _singleActions = new List<SingleAction>();
            _delta = delta;

            foreach (NoteData data in dataList)
            {
                Vector3 newPosition = data.Position + delta;
                _singleActions.Add(new MoveNote(data, newPosition));
            }

            Inverse = CreateInverse();
        }
        public MoveNotes(List<SingleAction> singleActions) : base(singleActions) { }

        public override Action CreateInverse()
        {
            return new MoveNotes(GetSingleActionInverses());
        }
        public override string ToString()
        {
            if (_singleActions.Count == 0) return _singleActions[0].ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append("Move ");
            sb.Append(_singleActions.Count);
            sb.Append(" notes by ");
            sb.Append(Vector3ToXYOrderedPairString(_delta));
            return sb.ToString();
        }
    }
}