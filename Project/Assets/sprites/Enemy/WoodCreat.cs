using System.Diagnostics;
using UnityEngine;
using UnityEditor.VersionControl;
using Debug = UnityEngine.Debug;

public class WoodCreat : LivingEntity
{
    public override void TakeDamage(float damage)
    {
        if (damage >= Health && !IsDead)
        {
            OnDeath += () =>
            {
                Debug.Log("Wood Creat die!!!!!!!!!"); // ֱ�ӵ���Debug.Log
            };
        }

        // ���������������Ч����Ч�Ĵ���

        base.TakeDamage(damage);
    }
}
