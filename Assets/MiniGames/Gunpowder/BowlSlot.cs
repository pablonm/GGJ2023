using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BowlSlot : MonoBehaviour, IDropHandler
{
    public GameObject Kanji1;
    public GameObject Kanji2;
    public GameObject Kanji3;
    public void DropIngredient(Ingredient ingr)
    {
        ingr.transform.SetParent(transform);
        ingr.transform.localPosition = Vector3.zero;
    }
    
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        BowlSlot slot = eventData.pointerCurrentRaycast.gameObject.GetComponent<BowlSlot>();
        if (slot != null)
        {
            Ingredient ingr = eventData.pointerDrag.GetComponent<Ingredient>();
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
            GunpowderWinConditions.AddIngredient(ingr.ingredientName);
        }
    }
}