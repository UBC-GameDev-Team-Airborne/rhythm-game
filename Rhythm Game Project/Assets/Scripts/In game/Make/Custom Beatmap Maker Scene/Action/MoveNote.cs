using Data;
using System.Text;
using UnityEngine;

namespace CustomBeatmapMaker.Action
{
    public class MoveNote : SingleAction
    {
        private Vector3 _oldPosition;
        private Vector3 _newPosition;

        public MoveNote(NoteData data, Vector3 newPosition)
        {
            _data = data;
            _oldPosition = data.Position;
            _newPosition = newPosition;

            Inverse = CreateInverse();
        }
        public override void Perform()
        {
            throw new System.NotImplementedException();
        }
        public override SingleAction CreateInverse()
        {
            NoteData inverseData = new NoteData(_newPosition, _data.Scale, _data.Height);
            return new MoveNote(inverseData, _oldPosition);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Move note from ");
            sb.Append(Vector3ToXYOrderedPairString(_oldPosition));
            sb.Append(" to ");
            sb.Append(Vector3ToXYOrderedPairString(_newPosition));

            return sb.ToString();
        }
    }
}