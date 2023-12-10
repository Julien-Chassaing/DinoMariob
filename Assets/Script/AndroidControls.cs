using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AndroidControls : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isClicked = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isClicked = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isClicked = false;
    }
}
