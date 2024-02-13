using System.Text;
using UnityEngine;

namespace CustomBeatmapMaker.Action
{
    public abstract class Action
    {
        public Action Inverse;
        public static string Vector3ToXYOrderedPairString(Vector3 vector3)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("(");
            sb.Append(vector3.x);
            sb.Append(',');
            sb.Append(vector3.y);
            sb.Append(")");

            return sb.ToString();
        }

        public abstract void Perform();
        public abstract Action CreateInverse();
        public abstract override string ToString();
    }
}