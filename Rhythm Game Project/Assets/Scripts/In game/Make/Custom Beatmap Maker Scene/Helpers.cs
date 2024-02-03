using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomBeatmapMaker
{
    public class Helpers
    {
        public static Vector3 GetMousePosition()
        {
            Vector3 mouseScreenSpacePos = Input.mousePosition;
            mouseScreenSpacePos.z = 1;
            Vector3 mouseWorldPointPos = Camera.main.ScreenToWorldPoint(mouseScreenSpacePos);

            return mouseWorldPointPos;
        }
    }
}

