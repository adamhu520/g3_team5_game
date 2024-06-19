using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Runtime.CompilerServices;

public class Beetle : LivingEntity
{
    [Header("AI")]
    public Transform target;
    public AIPath aiPath;

    [Header("Helee")]
    public LayerMask whatToHit;
    public float damage = 10;
    public float hitRate = 1.0f;
    private float _lastHit;
    
    private Animator _animator;

    public void Setup(Transform player, float upgrade)
    {
        target = player;
        aiPath.maxSpeed += upgrade;
        startHealth += upgrade * 5;
        damage += upgrade * 2;
        hitRate += upgrade * 2;
    }

    protected override void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
        aiPath = GetComponent<AIPath>();
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        aiPath.destination = target.position;
        if (aiPath.reachedDestination)
        {
            //Hit player
            _animator.SetBool(id: AnimatorHash1.IsMoving, value: false);
            if (Time.time > _lastHit + 1 / hitRate)
            {
                Hit(); 
                _lastHit = Time.time;

            }
        }
        else
        {
            _animator.SetBool(id: AnimatorHash1.IsMoving, value: true);
        }
    }

    private void Hit()
    {
        Vector3 selfPosition = transform.position;
        // Direction to target
        Vector3 targetDirection = (target.position - selfPosition).normalized;
        RaycastHit2D hit2D = Physics2D.Raycast(origin: (Vector2)selfPosition, (Vector2)targetDirection, aiPath.endReachedDistance + 2.0f, whatToHit);
        if (hit2D.collider !=  null)
        {
            Debug.Log(message: $"Hit player {hit2D.transform.name}");
           IDamageable damageable = hit2D.transform.GetComponent<IDamageable>();
           damageable?.TakeDamage(damage);
        }

    }
}
