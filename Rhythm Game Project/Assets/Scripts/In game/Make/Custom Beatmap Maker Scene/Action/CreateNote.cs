using Data;
using System.Text;

namespace CustomBeatmapMaker.Action
{
    public class CreateNote : SingleAction
    {
        public CreateNote(NoteData data)
        {
            _data = data;
            Inverse = CreateInverse();
        }
        public override void Perform()
        {
            throw new System.NotImplementedException();
        }
        public override SingleAction CreateInverse()
        {
            return new DeleteNote(_data);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Create ");
            sb.Append(_data.Height);
            sb.Append(" note at ");
            sb.Append(Vector3ToXYOrderedPairString(_data.Position));

            return sb.ToString();
        }
    }
}