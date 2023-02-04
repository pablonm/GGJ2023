using UnityEngine;

namespace MiniGames.PlanetsDiscovery.Scripts
{
    public class Orbit : MonoBehaviour
    {
        public float xSpread;
        public float ySpread;
        private Transform _centerPoint;
        public bool IsOrbiting { get; } = false;

        public float rotSpeed;

        private float _timer = 0;
    
        void Start()
        {
            _centerPoint = GameObject.Find("Sun").transform;
        }

        void Update()
        {
            if (IsOrbiting)
            {
                _timer += Time.deltaTime * rotSpeed;
                Rotate();
            }
        }

        void Rotate()
        {
            float x = -Mathf.Cos(_timer) * xSpread;
            float y = Mathf.Sin(_timer) * ySpread;
            Vector3 pos = new Vector2(x, y);
            transform.position = pos + _centerPoint.position;
        }
    
    }
}
