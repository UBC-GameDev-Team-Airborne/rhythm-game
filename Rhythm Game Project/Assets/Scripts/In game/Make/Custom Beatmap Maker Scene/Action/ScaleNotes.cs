using Data;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace CustomBeatmapMaker.Action
{
    public class ScaleNotes : MultiAction
    {
        private Vector3 _delta;

        public ScaleNotes(List<NoteData> dataList, Vector3 delta)
        {
            _singleActions = new List<SingleAction>();
            _delta = delta;

            foreach (NoteData data in dataList)
            {
                Vector3 newScale = data.Scale + delta;
                _singleActions.Add(new ScaleNote(data, newScale));
            }

            Inverse = CreateInverse();
        }
        public ScaleNotes(List<SingleAction> singleActions) : base(singleActions) { }

        public override void Perform()
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            if (_singleActions.Count == 0) return _singleActions[0].ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append("Scale ");
            sb.Append(_singleActions.Count);
            sb.Append(" notes by ");
            sb.Append(_delta.x);
            return sb.ToString();
        }
    }
}