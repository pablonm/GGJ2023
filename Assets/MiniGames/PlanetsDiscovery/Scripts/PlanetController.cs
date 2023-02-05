using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MiniGames.PlanetsDiscovery.Scripts
{
    public class PlanetController : MonoBehaviour
    {
        public void ReleaseThis()
        {
            SFXController.Play("select");
            PlanetsChecklist.Instance.ReleasePlanet((Planets) Enum.Parse(typeof(Planets), gameObject.name));
        }
    }
}