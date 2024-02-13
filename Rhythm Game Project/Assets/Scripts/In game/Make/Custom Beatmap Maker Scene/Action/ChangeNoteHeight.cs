using Data;
using System.Text;
using UnityEngine;

namespace CustomBeatmapMaker.Action
{
    public class ChangeNoteHeight : SingleAction
    {
        private Note.Heights _oldHeight;
        private Note.Heights _newHeight;

        public ChangeNoteHeight(NoteData data, Note.Heights endHeight)
        {
            _data = data;
            _oldHeight = data.Height;
            _newHeight = endHeight;
        }

        public override void Perform()
        {
            throw new System.NotImplementedException();
        }
        public override Action CreateInverse()
        {
            NoteData inverseData = new NoteData(_data.Position, _data.Scale, _newHeight);
            return new ChangeNoteHeight(inverseData, _oldHeight);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Change height of note at ");
            sb.Append(Vector3ToXYOrderedPairString(_data.Position));
            sb.Append(" from ");
            sb.Append(_oldHeight);
            sb.Append(" to ");
            sb.Append(_newHeight);

            return sb.ToString();
        }
    }
}