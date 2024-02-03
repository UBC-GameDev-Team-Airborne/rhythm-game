using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace CustomBeatmapMaker
{
    public class Note : MonoBehaviour
    {
        public StatusTracker Status;
        public NoteContainer Container;
        public bool IsQueuedForDeletion = false;

        private bool _isTouchingMouse = false;

        private bool _isScaling = false;
        private float _scaleStartX;
        private float _mouseStartX;



        void Update()
        {
            if (_isScaling) CalculateScale();

            if (Input.GetMouseButtonDown(0))
            {
                OnMouseDown();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                OnMouseUp();
            }
        }

        void OnMouseDown()
        {
            if (!_isTouchingMouse) return;
            
            switch (Status.CurrentTool)
            {
                case StatusTracker.Tools.Remove:
                    OnMouseDownRemove();
                    break;
                case StatusTracker.Tools.Scale:
                    OnMouseDownScale();
                    break;
                default:
                    break;
            }    
        }
        private void OnMouseUp()
        {
            switch (Status.CurrentTool)
            {
                case StatusTracker.Tools.Scale:
                    OnMouseUpScale();
                    break;
                default:
                    break;
            }
        }

        void OnMouseDownRemove()
        {
            IsQueuedForDeletion = true;
            Container.CalculateHighestNote();
            Destroy(gameObject);
        }
        void OnMouseDownScale()
        {
            _mouseStartX = Helpers.GetMousePosition().x;
            _scaleStartX = gameObject.transform.localScale.x;
            _isScaling = true;
        }
        void OnMouseUpScale()
        {
            _isScaling = false;
        }

        void OnMouseOver()
        {
            _isTouchingMouse = true;
        }

        void OnMouseExit()
        {
            _isTouchingMouse = false;
        }

        void CalculateScale()
        {
            var scale = gameObject.transform.localScale;
            var mouseCurrentX = Helpers.GetMousePosition().x;
            var newScaleX = Math.Max(_scaleStartX + mouseCurrentX - _mouseStartX, .4f);
            gameObject.transform.localScale = new Vector3(newScaleX, scale.y, scale.z);
        }
    }
}
