using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CustomBeatmapMaker
{
    public class Toolbar : MonoBehaviour
    {
        public Manager CurrentManager;
        public Text CurrentToolIndicator;

        public void OnAddButtonPressed()
        {
            CurrentManager.CurrentTool = Manager.Tools.Add;
            CurrentToolIndicator.text = "Add";
        }

        public void OnRemoveButtonPressed()
        {
            CurrentManager.CurrentTool = Manager.Tools.Remove;
            CurrentToolIndicator.text = "Remove";
        }
    }
}