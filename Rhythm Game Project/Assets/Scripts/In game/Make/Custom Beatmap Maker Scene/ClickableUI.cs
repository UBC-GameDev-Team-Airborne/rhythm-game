using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CustomBeatmapMaker
{
    public class ClickableUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Manager CurrentManager;
        public void OnPointerEnter(PointerEventData eventData)
        {
            CurrentManager.MouseIsHoveringClickableUI = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            CurrentManager.MouseIsHoveringClickableUI = false;
        }
    }
}
