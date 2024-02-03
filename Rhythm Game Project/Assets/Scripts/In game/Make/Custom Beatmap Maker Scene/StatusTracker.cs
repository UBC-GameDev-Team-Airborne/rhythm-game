using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomBeatmapMaker
{
    public class StatusTracker : MonoBehaviour
    {
        public enum Tools { Add, Remove };

        public Tools CurrentTool;
        public SongMetadata Metadata;
        public bool MouseIsHoveringClickableUI;

        void Start()
        {
            CurrentTool = Tools.Add;
            MouseIsHoveringClickableUI = false;
        }
    }
}