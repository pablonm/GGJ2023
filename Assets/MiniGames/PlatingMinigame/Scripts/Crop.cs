using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MiniGames.PlatingMinigame.Scripts
{
    public class Crop : MonoBehaviour, IDropHandler
    {
        public Animator humanAnimator;
        private CropState _cropState = CropState.Raw;
        public Image image;
        public List<Sprite> stateSprites = new List<Sprite>();
        
        void IDropHandler.OnDrop(PointerEventData eventData)
        {
            Crop crop = eventData.pointerCurrentRaycast.gameObject.GetComponent<Crop>();
            if (crop != null)
            {
                PlantingItem item = eventData.pointerDrag.GetComponent<PlantingItem>();
                if (item != null)
                {
                    ManageStates(item);
                }
            }
        }

        private void ManageStates(PlantingItem item)
        {
            if ((int)_cropState == (int)item.itemName)
                UpdateState(item);
            if (_cropState == CropState.Completed)
                StartCoroutine(CompleteLevel());
        }

        IEnumerator CompleteLevel()
        {
            yield return new WaitForSeconds(.5f);
            image.sprite = stateSprites[(int)CropState.Completed+1]; 
            humanAnimator.SetTrigger("Finished");
            yield return new WaitForSeconds(2f);
            GameState.SetNextAge(Ages.End);
            SFXController.Play("success");
            FadeToBlack.FadeOut(1f, null);
            yield return new WaitForSeconds(1f);
            CursorController.Instance.currentMinigame = CursorController.Minigame.MainScene;
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
            
        }

        private void UpdateState(PlantingItem item)
        {
            item.gameObject.SetActive(false);
            SFXController.Play("click");
            _cropState++;
            image.sprite = stateSprites[(int)_cropState];
            if (item.itemName == ItemName.Shovel){
                GameObject.Find("/InventoryUI/Inventory/Background/Slots/Slot (4)/DirtItem").SetActive(true);
            }
        }

        private enum CropState
        {
            Raw,
            Hoed,
            Digged,
            Planted,
            Covered,
            Completed
        }
    }
}