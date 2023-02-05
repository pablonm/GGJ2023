using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Ingredient : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Vector3 startingSlot;
    public IngredientNames ingredientName;

    Image img;
    
    private void Awake()
    {
        img = GetComponent<Image>();
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        img.raycastTarget = false;
        startingSlot = transform.parent.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().alpha = 1;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        img.raycastTarget = true;
        transform.position = startingSlot;
        GetComponent<CanvasGroup>().alpha = 0;
    }
}

public enum IngredientNames { carbon, azufre, potasio };