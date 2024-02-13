using Data;
using System.Collections.Generic;
using System.Text;

namespace CustomBeatmapMaker.Action
{
    public class CreateNotes : MultiAction
    {
        public CreateNotes(List<NoteData> data) : base()
        {
            _data = data;
        }
        public override void Perform()
        {
            throw new System.NotImplementedException();
        }
        public override Action CreateInverse()
        {
            return new DeleteNotes(_data);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Create notes");
            return sb.ToString();
        }
    }
}