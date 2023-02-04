using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AqueductPiece : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    public PipeTypes pipeType;
    public PipeOrientations currentOrientation = PipeOrientations.Up;
    public AqueductSlot startingSlot;
    Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
        ApplyRotation();
    }

    public void Rotate()
    {
        currentOrientation += 1;
        SFXController.Play("piece");
        if (currentOrientation > PipeOrientations.Left)
            currentOrientation = PipeOrientations.Up;
        ApplyRotation();
        RomanPipesWinConditions.CheckWinConditions();
    }

    void ApplyRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, (int)currentOrientation * -90f);
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        img.raycastTarget = false;
        startingSlot = transform.parent.gameObject.GetComponent<AqueductSlot>();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        img.raycastTarget = true;
        startingSlot.PlacePipe(this);
        SFXController.Play("piece");
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Rotate();
    }
}

public enum PipeOrientations { Up, Right, Down, Left }
public enum PipeTypes { Pipe, Superior, Inferior }