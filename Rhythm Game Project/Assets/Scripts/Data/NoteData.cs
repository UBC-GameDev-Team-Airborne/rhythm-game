using CustomBeatmapMaker;
using System.Text;
using UnityEngine;

namespace Data
{
    public class NoteData
    {
        public Vector3 Position;
        public Vector3 Scale;
        public Note.Heights Height;

        public NoteData(Vector3 position, Vector3 scale, Note.Heights height)
        {
            Position = position;
            Scale = scale;
            Height = height;
        }
    }
}