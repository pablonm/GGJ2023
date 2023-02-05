using UnityEngine;

namespace MiniGames.PlanetsDiscovery.Scripts
{
    public class Orbit : MonoBehaviour
    {
        public float xSpread;
        public float ySpread;
        private Transform _centerPoint;
        public bool isOrbiting = false;

        public float rotSpeed;

        [SerializeField] private float _timer = 0;
        private Vector2 _initialPosition;
    
        void Start()
        {
            _centerPoint = GameObject.Find("Sun").transform;
            _initialPosition = transform.position;
            _timer = Vector2.SignedAngle(_initialPosition, Vector2.right);
        }

        void Update()
        {
            if (isOrbiting)
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
