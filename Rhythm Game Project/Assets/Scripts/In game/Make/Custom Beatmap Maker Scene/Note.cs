using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace CustomBeatmapMaker
{
    public class Note : MonoBehaviour
    {
        public enum Heights { Down, Middle, Up }

        public GameObject SpriteObject;
        public StatusTracker Status;
        public NoteContainer Container;

        public bool IsQueuedForDeletion = false;

        private Heights _height = Heights.Middle;
        public Heights Height
        {
            get => _height;
            set
            {
                _height = value;

                Color newColor;
                if (value == Heights.Down) newColor = Color.red;
                else if (value == Heights.Middle) newColor = Color.blue;
                else newColor = Color.green;
                SpriteObject.GetComponent<SpriteRenderer>().color = newColor;
            }
        }
        
        private bool _isTouchingMouse = false;
        private bool _isMoving = false;
        private bool _isScaling = false;
        private bool _isShiftingHeight = false;
        private Vector3 _startPos;
        private Heights _startHeight;
        private Vector3 _mouseStartPos;
        private float _scaleStartX;



        void Update()
        {
            if (_isMoving) MoveToMouse();
            else if (_isScaling) CalculateScale();
            else if (_isShiftingHeight) ShiftHeight();

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
                case StatusTracker.Tools.Height:
                    OnMouseDownHeight();
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
        void OnMouseDownHeight()
        {
            _mouseStartPos = Helpers.GetMousePosition();
            _startHeight = Height;
            _isShiftingHeight = true;
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
                case StatusTracker.Tools.Height:
                    OnMouseUpHeight();
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
        void OnMouseUpHeight()
        {
            _isShiftingHeight = false;
        }

        void OnMouseOver()
        {
            _isTouchingMouse = true;
        }
        void OnMouseExit()
        {
            _isTouchingMouse = false;
        }

        void MoveToMouse()
        {
            Vector3 diffOnStart = _startPos - _mouseStartPos;
            gameObject.transform.position = Helpers.GetMousePosition() + diffOnStart;
        }
        void CalculateScale()
        {
            Vector3 scale = gameObject.transform.localScale;
            float mouseCurrentX = Helpers.GetMousePosition().x;
            float mousePosDiff = mouseCurrentX - _mouseStartPos.x;
            float newScaleX = Math.Max(_scaleStartX + mousePosDiff, .4f);
            gameObject.transform.localScale = new Vector3(newScaleX, scale.y, scale.z);
        }
        void ShiftHeight()
        {
            float mouseCurrentY = Helpers.GetMousePosition().y;
            float mousePosDiff = mouseCurrentY - _mouseStartPos.y;

            int newHeight = (int)_startHeight;
            newHeight += (int)Math.Round(mousePosDiff);
            newHeight = Math.Max((int)Heights.Down, newHeight);
            newHeight = Math.Min((int)Heights.Up, newHeight);

            Height = (Heights)newHeight;
        }
    }
}
