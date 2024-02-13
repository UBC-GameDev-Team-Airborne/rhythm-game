using Data;
using System.Text;
using UnityEngine;

namespace CustomBeatmapMaker.Action
{
    public class ScaleNote : SingleAction
    {
        private Vector3 _oldScale;
        private Vector3 _newScale;

        public ScaleNote(NoteData data, Vector3 endScale) : base()
        {
            _data = data;
            _oldScale = data.Position;
            _newScale = endScale;
        }
        public override void Perform()
        {
            throw new System.NotImplementedException();
        }
        public override Action CreateInverse()
        {
            NoteData inverseData = new NoteData(_data.Position, _newScale, _data.Height);
            return new ScaleNote(inverseData, _oldScale);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Scale note from ");
            sb.Append(_oldScale.x);
            sb.Append(" to ");
            sb.Append(_newScale.x);

            return sb.ToString();
        }
    }
}