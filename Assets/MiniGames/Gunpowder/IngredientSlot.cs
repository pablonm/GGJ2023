using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngredientSlot : MonoBehaviour, IDropHandler
{
    public GameObject Kanji1;
    public GameObject Kanji2;
    public GameObject Kanji3;
    public void DropIngredient(Ingredient ingr)
    {
        ingr.transform.SetParent(transform);
        ingr.transform.localPosition = Vector3.zero;
        GunpowderWinConditions.CheckWinConditions();
    }
    
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        IngredientSlot slot = eventData.pointerCurrentRaycast.gameObject.GetComponent<IngredientSlot>();
        if (slot != null)
        {
            Ingredient ingr = eventData.pointerDrag.GetComponent<Ingredient>();
            if (ingr != null) ingr.startingSlot = this;
            switch (ingr.ingredientName)
            {
                case IngredientNames.carbon:
                    Kanji1.SetActive(true);
                    break;
                case IngredientNames.azufre:
                    Kanji2.SetActive(true);
                    break;
                case IngredientNames.potasio:
                    Kanji3.SetActive(true);
                    break;
            }
        }
    }
}
