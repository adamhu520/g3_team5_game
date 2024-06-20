using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameTesting : MonoBehaviour
{
    public PopupText popupText;
    public Transform player;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PopupText temp = Instantiate(popupText, player.position, Quaternion.identity);
            temp.Setup(Random.Range(1, 100), Random.Range(1, 100) < 30);//剪切加入射击效果
        }
    }

}
