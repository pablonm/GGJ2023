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
        SFXController.Play("polvora");
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        img.raycastTarget = true;
        transform.position = startingSlot;
    }
}

public enum IngredientNames { carbon, azufre, potasio };