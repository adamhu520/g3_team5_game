
using UnityEngine;

public class weaponSystem : MonoBehaviour
{
    [SerializeField] private Transform firepoint;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(AnimatorHash.IsShooting, false);

        if (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0))
        {
            _animator.SetBool(AnimatorHash.IsShooting, true);
            Debug.Log("射击");

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);
            Vector2 firePointPosition = new Vector2(firepoint.position.x, firepoint.position.y);
            Vector2 shootDirection = mousePosition2D - firePointPosition;
            Debug.DrawLine(firePointPosition, shootDirection * 100, Color.red);
        }
    }
}
