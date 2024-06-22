using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnemyHP = 100;
        damege = 10;
    }

    public int EnemyHP;
    public int damege;
    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D o)
    {
        if (o.tag=="Player")
        {
            PlayerHp.Instance.SetPlayerHp(0.01f);
        }

        if (o.tag == "Bundle")
        {
            EnemyHP -= damege;

            if (EnemyHP<=0)
            {
              
                Destroy(this.gameObject);
            }
        }
    }


    private void OnDestroy()
    {
        GameCtrl.Instance.UPdateEnmyCount();
    }
}
