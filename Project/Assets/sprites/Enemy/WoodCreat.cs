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
                Debug.Log("Wood Creat die!!!!!!!!!"); // 直接调用Debug.Log
            };
        }

        // 在这里添加死亡特效和音效的代码

        base.TakeDamage(damage);
    }
}
