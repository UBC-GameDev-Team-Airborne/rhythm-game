using Data;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace CustomBeatmapMaker.Action
{
    public class MoveNotes : MultiAction
    {
        private Vector3 _delta;

        public MoveNotes(List<NoteData> data, Vector3 delta) : base()
        {
            _data = data;
            _delta = delta;
        }
        public override void Perform()
        {
            throw new System.NotImplementedException();
        }
        public override Action CreateInverse()
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Move notes by ");
            sb.Append(Vector3ToXYOrderedPairString(_delta));

            return sb.ToString();
        }
    }
}