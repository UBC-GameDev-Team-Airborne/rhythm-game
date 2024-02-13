using Data;
using System.Collections.Generic;
using System.Text;

namespace CustomBeatmapMaker.Action
{
    public class DeleteNotes : MultiAction
    {
        public DeleteNotes(List<NoteData> data) : base()
        {
            _data = data;
        }
        public override void Perform()
        {
            throw new System.NotImplementedException();
        }
        public override Action CreateInverse()
        {
            return new CreateNotes(_data);
        }
        public override string ToString()
        {
            if (_data.Count == 1) return _data[0].ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append("Delete notes");
            return sb.ToString();
        }
    }
}