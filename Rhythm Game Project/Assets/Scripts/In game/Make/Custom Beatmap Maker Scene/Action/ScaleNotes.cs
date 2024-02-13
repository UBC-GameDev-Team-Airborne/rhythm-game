using Data;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace CustomBeatmapMaker.Action
{
    public class ScaleNotes : MultiAction
    {
        private Vector3 _delta;

        public ScaleNotes(List<NoteData> data, Vector3 delta) : base()
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

            sb.Append("Scale notes by ");
            sb.Append(_delta.x);

            return sb.ToString();
        }
    }
}