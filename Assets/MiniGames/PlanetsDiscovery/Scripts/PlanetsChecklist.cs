using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace MiniGames.PlanetsDiscovery.Scripts
{
    public class PlanetsChecklist : MonoBehaviour
    {
        public List<Image> planetsImages = new List<Image>();
        private List<int> _completedPlanets = new List<int>();
        public static PlanetsChecklist Instance;
        private Camera _mainCamera;
        [SerializeField] private bool _isCompleted;
        [SerializeField] private CanvasGroup canvasGroup;

        public float ZoomChange;
        public float SmoothChange;
        public float MinSize, MaxSize;

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
            
            _mainCamera = Camera.main;
        }


        public void ReleasePlanet(Planets planetName)
        {
            Orbit planetOrbit = GameObject.Find($"/Sun/{planetName}Orbit/{planetName}").GetComponent<Orbit>();
            planetOrbit.isOrbiting = true;
            Image planetImage = planetsImages[(int)planetName];
            planetImage.color = Color.white;
            _completedPlanets.Add(1);
            if (planetsImages.Count == _completedPlanets.Count)
                FinishMinigame();
        }

        public void FinishMinigame()
        {
            _mainCamera.GetComponent<PlanetsCamera>().isCompleted = true;
            _isCompleted = true;
            StartCoroutine(EndMinigame());

        }
        
        IEnumerator EndMinigame()
        {
            yield return new WaitForSeconds(2f);
            GameState.SetNextAge(Ages.Middle);
            SFXController.Play("success");
            FadeToBlack.FadeOut(1f, null);
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }

        private void Update()
        {
            if (_isCompleted && _mainCamera.orthographicSize < 12f)
            {
                _mainCamera.orthographicSize += SmoothChange * Time.deltaTime * ZoomChange;
                _mainCamera.orthographicSize = Mathf.Clamp(_mainCamera.orthographicSize, MinSize, MaxSize);
            }

            if (_isCompleted && canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime;
            }
        }
    }
    public enum Planets
    {
        Mercury,
        Mars,
        Earth,
        Venus,
        Jupiter,
        Saturn,
        Uranus,
        Neptune
    }
}