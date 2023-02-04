using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace MiniGames.PlatingMinigame.Scripts
{
    public class PlantingItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public ItemName itemName;
        public SlotsUI startingSlot;

        private Image _icon;

        private void Awake()
        {
            _icon = GetComponent<Image>();
            transform.position = startingSlot.transform.position;
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            _icon.raycastTarget = false;
            startingSlot = transform.parent.gameObject.GetComponent<SlotsUI>();
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }
        
        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            _icon.raycastTarget = true;
            transform.position = startingSlot.transform.position;
        }

    }

    public enum ItemName
    {
        Hoe,
        Shovel,
        Seed,
        Dirt,
        Water,
    }
}