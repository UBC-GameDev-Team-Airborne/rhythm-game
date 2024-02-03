using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomBeatmapMaker
{
    public class Toolbar : MonoBehaviour
    {
        public StatusTracker Status;

        public void OnAddButtonPressed()
        {
            Status.CurrentTool = StatusTracker.Tools.Add;
        }

        public void OnRemoveButtonPressed()
        {
            Status.CurrentTool = StatusTracker.Tools.Remove;
        }
    }
}