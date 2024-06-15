<<<<<<< Updated upstream
using UnityEngine;

public class AimController : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
        if (_mainCamera == null)
        {
            Debug.LogError("有误，找不到摄像机");
        }
    }

    private void Update()
    {
        Vector3 position = _mainCamera.WorldToScreenPoint(transform.position);
        Vector3 direction = Input.mousePosition - position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
    }
}
=======
using UnityEngine;

public class AimController : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
        if (_mainCamera == null)
        {
            Debug.LogError("有误，找不到摄像机");
        }
    }

    private void Update()
    {
        Vector3 position = _mainCamera.WorldToScreenPoint(transform.position);
        Vector3 direction = Input.mousePosition - position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
    }
}
>>>>>>> Stashed changes
