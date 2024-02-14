using Make.CustomBeatmapMaker;
using System.Text;
using UnityEngine;

namespace Data
{
    public class NoteData
    {
        public enum Heights { Bottom, Middle, Top }

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