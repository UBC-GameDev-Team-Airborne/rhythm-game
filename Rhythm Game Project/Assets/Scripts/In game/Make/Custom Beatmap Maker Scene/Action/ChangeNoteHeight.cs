using Data;
using System.Text;
using UnityEngine;

namespace CustomBeatmapMaker.Action
{
    public class ChangeNoteHeight : SingleAction
    {
        private Vector3 _startHeight;
        private Vector3 _endHeight;

        public ChangeNoteHeight(NoteData data, Vector3 startHeight, Vector3 endHeight)
        {
            _data = data;
            _startHeight = startHeight;
            _endHeight = endHeight;
        }

        public override void Perform()
        {
            throw new System.NotImplementedException();
        }
        public override Action CreateInverse()
        {
            return new ChangeNoteHeight(_data, _endHeight, _startHeight);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Change height of note at ");
            sb.Append(Vector3ToXYOrderedPairString(_data.Position));
            sb.Append(" from ");
            sb.Append(_startHeight);
            sb.Append(" to ");
            sb.Append(_endHeight);

            return sb.ToString();
        }
    }
}