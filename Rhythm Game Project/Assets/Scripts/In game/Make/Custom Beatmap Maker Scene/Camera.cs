using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomBeatmapMaker
{
    public class CameraScript : MonoBehaviour
    {
        public ScrollbarScript Scrollbar;

        void Update()
        {
            var deltaY = Input.mouseScrollDelta.y;
            if (Math.Abs(deltaY) > 0)
            {
                OnMouseScroll(deltaY);
            }

        }

        void OnMouseScroll(float mouseDelta)
        {
            var pos = transform.position;
            float newY = pos.y + (mouseDelta / 2f);
            transform.position = new Vector3(pos.x, Math.Max(newY, 0f), pos.z);

            Scrollbar.UpdateValue();
        }
    }
}
