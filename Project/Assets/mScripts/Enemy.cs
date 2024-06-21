/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnemyHP = 100;
    }

    public int EnemyHP;
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
            PlayerHp.Instance.SetPlayerHp(0.1f);
        }

        if (o.tag == "Bundle")
        {
            EnemyHP -= 10;

            if (EnemyHP<=0)
            {
                GameCtrl.Instance.UPdateEnmyCount();
                Destroy(this.gameObject);
            }
        }
    }
}
*/