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
        private bool _isMoving = false;
        private bool _isScaling = false;
        
        private Vector3 _startPos;
        private Vector3 _mouseStartPos;
        private float _scaleStartX;



        void Update()
        {
            if (_isScaling) CalculateScale();
            if (_isMoving) MoveToMouse();

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
                case StatusTracker.Tools.Move:
                    OnMouseDownMove();
                    break;
                case StatusTracker.Tools.Scale:
                    OnMouseDownScale();
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
        void OnMouseDownMove()
        {
            _mouseStartPos = Helpers.GetMousePosition();
            _startPos = gameObject.transform.position;
            _isMoving = true;
        }
        void OnMouseDownScale()
        {
            _mouseStartPos = Helpers.GetMousePosition();
            _scaleStartX = gameObject.transform.localScale.x;
            _isScaling = true;
        }

        void OnMouseUp()
        {
            switch (Status.CurrentTool)
            {
                case StatusTracker.Tools.Move:
                    OnMouseUpMove();
                    break;
                case StatusTracker.Tools.Scale:
                    OnMouseUpScale();
                    break;
                default:
                    break;
            }
        }
        void OnMouseUpMove()
        {
            _isMoving = false;
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
            Vector3 scale = gameObject.transform.localScale;
            float mouseCurrentX = Helpers.GetMousePosition().x;
            float mousePosDiff = mouseCurrentX - _mouseStartPos.x;
            float newScaleX = Math.Max(_scaleStartX + mousePosDiff, .4f);
            gameObject.transform.localScale = new Vector3(newScaleX, scale.y, scale.z);
        }
        void MoveToMouse()
        {
            Vector3 diffOnStart = _startPos - _mouseStartPos;
            gameObject.transform.position = Helpers.GetMousePosition() + diffOnStart;
        }
    }
}
