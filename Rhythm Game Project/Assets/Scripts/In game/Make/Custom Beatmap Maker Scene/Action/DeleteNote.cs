using Data;
using System.Text;

namespace CustomBeatmapMaker.Action
{
    public class DeleteNote : SingleAction
    {
        public DeleteNote(NoteData data) : base()
        {
            _data = data;
        }
        public override void Perform()
        {
            throw new System.NotImplementedException();
        }
        public override Action CreateInverse()
        {
            return new CreateNote(_data);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Delete note at ");
            sb.Append(Vector3ToXYOrderedPairString(_data.Position));

            return sb.ToString();
        }
    }
}