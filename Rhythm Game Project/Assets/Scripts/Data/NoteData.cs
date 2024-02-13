using CustomBeatmapMaker;
using System.Text;
using UnityEngine;

namespace Data
{
    public class NoteData
    {
        public enum Heights { Down, Middle, Up }

        public Vector3 Position;
        public Vector3 Scale;
        public Heights Height;

        public NoteData(Vector3 position, Vector3 scale, Heights height)
        {
            Position = position;
            Scale = scale;
            Height = height;
        }
    }
}