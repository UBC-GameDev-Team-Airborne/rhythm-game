using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomBeatmapMaker
{
/*    public class NoteContainer : MonoBehaviour
    {
        const float highestNoteDefault = 5f;

        public StatusTracker Status;
        public ScrollbarScript Scrollbar;
        public GameObject NotePrefab;

        public float HighestNote = highestNoteDefault;

        public void CalculateHighestNote()
        {
            var children = GetChildren();

            if (children.Count == 0)
            {
                HighestNote = highestNoteDefault;
                return;
            }

            float highestSoFar = highestNoteDefault;
            foreach (var child in children)
            {
                var childScript = child.GetComponent<Note>();
                if (!childScript.IsQueuedForDeletion && child.transform.position.y > highestSoFar)
                {
                    highestSoFar = child.transform.position.y;
                }
            }
            HighestNote = highestSoFar;

            Scrollbar.UpdateValue();
        }

        private List<GameObject> GetChildren()
        {
            var children = new List<GameObject>();
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                GameObject child = gameObject.transform.GetChild(i).gameObject;
                children.Add(child);
            }
            return children;
        }

        private void Start()
        {
            CalculateHighestNote();
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
            if (Status.CurrentTool == StatusTracker.Tools.Add && !Status.MouseIsHoveringClickableUI)
            {
                AddNote();
            }
        }

        void AddNote()
        {
            Vector3 mousePos = Helpers.GetMousePosition();

            var noteObject = Instantiate(NotePrefab, mousePos, Quaternion.identity, transform);
            var noteScript = noteObject.GetComponent<Note>();
            noteScript.Status = Status;
            noteScript.Container = this;

            CalculateHighestNote();
        }

    }*/
}
