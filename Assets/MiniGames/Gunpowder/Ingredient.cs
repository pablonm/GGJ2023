using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Ingredient : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public IngredientSlot startingSlot;
    public IngredientNames ingredientName;

    Image img;
    
    private void Awake()
    {
        img = GetComponent<Image>();
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        img.raycastTarget = false;
        startingSlot = transform.parent.gameObject.GetComponent<IngredientSlot>();
        SFXController.Play("polvora");
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        img.raycastTarget = true;
        startingSlot.DropIngredient(this);
    }
}

public enum IngredientNames { carbon, azufre, potasio };