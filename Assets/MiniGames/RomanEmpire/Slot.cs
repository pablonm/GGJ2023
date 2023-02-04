using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public void PlacePipe(Pipe pipe)
    {
        pipe.transform.SetParent(transform);
        pipe.transform.localPosition = Vector3.zero;
        RomanPipesWinConditions.CheckWinConditions();
    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        Slot slot = eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>();
        if (slot != null)
        {
            Pipe pipe = eventData.pointerDrag.GetComponent<Pipe>();
            if (pipe != null)
                pipe.startingSlot = this;
        }
    }
}
