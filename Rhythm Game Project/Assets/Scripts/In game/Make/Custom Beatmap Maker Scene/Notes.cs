using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomBeatmapMaker
{
    public class Notes : MonoBehaviour
    {
        public StatusTracker Status;
        public GameObject NotePrefab;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnMouseDown();
            }
        }

        void OnMouseDown()
        {
            if (Status.CurrentTool == StatusTracker.Tools.Add && !Status.MouseIsHoveringClickableUI)
            {
                AddNote();
            }
        }

        void AddNote()
        {
            Vector3 mouseScreenSpacePos = Input.mousePosition;
            mouseScreenSpacePos.z = 1;
            Vector3 mouseWorldPointPos = Camera.main.ScreenToWorldPoint(mouseScreenSpacePos);

            var noteObject = Instantiate(NotePrefab, mouseWorldPointPos, Quaternion.identity, transform);
            var noteScript = noteObject.GetComponent<Note>();
            noteScript.Status = Status;
        }
    }
}
