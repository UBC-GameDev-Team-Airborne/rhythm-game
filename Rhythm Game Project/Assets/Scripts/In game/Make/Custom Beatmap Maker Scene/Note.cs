using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomBeatmapMaker
{
    public class Note : MonoBehaviour
    {
        public Manager CurrentManager;
        private bool _isTouchingMouse;

        void Start()
        {
            _isTouchingMouse = false;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnMouseDown();
            }
        }

        void OnMouseDown()
        {
            if (CurrentManager.CurrentTool == Manager.Tools.Remove && _isTouchingMouse)
            {
                Destroy(gameObject);
            }
        }

        void OnMouseOver()
        {
            _isTouchingMouse = true;
        }

        void OnMouseExit()
        {
            _isTouchingMouse = false;
        }
    }
}
