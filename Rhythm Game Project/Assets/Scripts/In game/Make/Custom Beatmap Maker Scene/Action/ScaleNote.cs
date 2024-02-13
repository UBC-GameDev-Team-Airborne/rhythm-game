using Data;
using System.Text;
using UnityEngine;

namespace CustomBeatmapMaker.Action
{
    public class ScaleNote : SingleAction
    {
        private Vector3 _startScale;
        private Vector3 _endScale;

        public ScaleNote(NoteData data, Vector3 startScale, Vector3 endScale) : base()
        {
            _data = data;
            _startScale = startScale;
            _endScale = endScale;
        }
        public override void Perform()
        {
            throw new System.NotImplementedException();
        }
        public override Action CreateInverse()
        {
            return new ScaleNote(_data, _endScale, _startScale);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Scale note from ");
            sb.Append(_startScale.x);
            sb.Append(" to ");
            sb.Append(_endScale.x);

            return sb.ToString();
        }
    }
}