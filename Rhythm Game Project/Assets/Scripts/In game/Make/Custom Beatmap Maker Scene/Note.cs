using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomBeatmapMaker
{
    public class Note : MonoBehaviour
    {
        public StatusTracker Status;
        public NoteContainer Container;
        public bool IsQueuedForDeletion = false;
        private bool _isTouchingMouse = false;

        void Start()
        {
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
            if (Status.CurrentTool == StatusTracker.Tools.Remove && _isTouchingMouse)
            {
                IsQueuedForDeletion = true;
                Container.CalculateHighestNote();
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
