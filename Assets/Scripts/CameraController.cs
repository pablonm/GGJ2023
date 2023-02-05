using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float smoothFactor;
    public static CameraController Instance;
    private Vector2 targetPosition;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
        Instance.targetPosition = Instance.transform.position;
    }

    public static void MoveTo(GameObject target)
    {
        Vector3 newPosition = new Vector3(target.transform.position.x, target.transform.position.y, Instance.transform.position.z);
        Instance.transform.position = newPosition;
        Instance.targetPosition = newPosition;
    }

    public static void MoveSmoothlyTo(GameObject target)
    {
        Instance.targetPosition = target.transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(targetPosition.x, targetPosition.y, transform.position.z), smoothFactor);
    }
}
