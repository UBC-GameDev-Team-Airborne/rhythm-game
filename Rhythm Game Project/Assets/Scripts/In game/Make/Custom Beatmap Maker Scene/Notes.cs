using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomBeatmapMaker
{
    public class Notes : MonoBehaviour
    {
        public Manager CurrentManager;
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
            if (CurrentManager.CurrentTool == Manager.Tools.Add && !CurrentManager.MouseIsHoveringClickableUI)
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
            noteScript.CurrentManager = CurrentManager;
        }
    }
}
