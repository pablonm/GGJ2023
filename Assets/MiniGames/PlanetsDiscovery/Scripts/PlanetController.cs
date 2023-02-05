using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MiniGames.PlanetsDiscovery.Scripts
{
    public class PlanetController : MonoBehaviour
    {
        public void ReleaseThis()
        {
            PlanetsChecklist.Instance.ReleasePlanet((Planets) Enum.Parse(typeof(Planets), gameObject.name));
        }
    }
}