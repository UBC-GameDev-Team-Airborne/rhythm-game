using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CustomBeatmapMaker
{
    public class Toolbar : MonoBehaviour
    {
        public StatusTracker Status;
        public Text CurrentToolIndicator;

        public void OnAddButtonPressed()
        {
            Status.CurrentTool = StatusTracker.Tools.Add;
            CurrentToolIndicator.text = "Add";
        }

        public void OnRemoveButtonPressed()
        {
            Status.CurrentTool = StatusTracker.Tools.Remove;
            CurrentToolIndicator.text = "Remove";
        }
    }
}