using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomBeatmapMaker
{
    public class Manager : MonoBehaviour
    {
        public enum Tools { Add, Remove };

        public Tools CurrentTool;
        public bool MouseIsHoveringClickableUI;

        void Start()
        {
            CurrentTool = Tools.Add;
            MouseIsHoveringClickableUI = false;
        }
    }
}
