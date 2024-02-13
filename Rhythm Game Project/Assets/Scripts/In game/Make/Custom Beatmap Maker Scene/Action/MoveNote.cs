using Data;
using System.Text;
using UnityEngine;

namespace CustomBeatmapMaker.Action
{
    public class MoveNote : SingleAction
    {
        private Vector3 _startPosition;
        private Vector3 _endPosition;

        public MoveNote(NoteData data, Vector3 startPosition, Vector3 endPosition) : base()
        {
            _data = data;
            _startPosition = startPosition;
            _endPosition = endPosition;
        }
        public override void Perform()
        {
            throw new System.NotImplementedException();
        }
        public override Action CreateInverse()
        {
            return new MoveNote(_data, _endPosition, _startPosition);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Move note from ");
            sb.Append(Vector3ToXYOrderedPairString(_startPosition));
            sb.Append(" to ");
            sb.Append(Vector3ToXYOrderedPairString(_endPosition));

            return sb.ToString();
        }
    }
}