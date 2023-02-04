using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AqueductSlot : MonoBehaviour, IDropHandler
{
    public void PlacePipe(AqueductPiece piece)
    {
        piece.transform.SetParent(transform);
        piece.transform.localPosition = Vector3.zero;
        RomanPipesWinConditions.CheckWinConditions();
    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        AqueductSlot slot = eventData.pointerCurrentRaycast.gameObject.GetComponent<AqueductSlot>();
        if (slot != null)
        {
            AqueductPiece pipe = eventData.pointerDrag.GetComponent<AqueductPiece>();
            if (pipe != null)
                pipe.startingSlot = this;
        }
    }
}
