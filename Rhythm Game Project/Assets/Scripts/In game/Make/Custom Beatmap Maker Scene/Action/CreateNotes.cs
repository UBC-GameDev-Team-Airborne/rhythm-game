using Data;
using System.Collections.Generic;
using System.Text;

namespace CustomBeatmapMaker.Action
{
    public class CreateNotes : MultiAction
    {
        public CreateNotes(List<NoteData> dataList)
        {
            _singleActions = new List<SingleAction>();

            foreach (NoteData data in dataList)
            {
                _singleActions.Add(new CreateNote(data));
            }

            Inverse = CreateInverse();
        }
        public CreateNotes(List<SingleAction> singleActions): base(singleActions) { }

        public override Action CreateInverse()
        {
            return new DeleteNotes(GetSingleActionInverses());
        }
        public override string ToString()
        {
            if (_singleActions.Count == 0) return _singleActions[0].ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append("Create ");
            sb.Append(_singleActions.Count);
            sb.Append(" notes");
            return sb.ToString();
        }
    }
}