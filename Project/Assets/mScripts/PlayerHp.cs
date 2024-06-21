using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHp : MonoBehaviour
{

    public static PlayerHp Instance;
    private void Awake()
    {
            Instance = this;
    }

    public Image Hpimg;
    public GameObject FaildWin;
    // Start is called before the first frame update
    void Start()
    {
        Hpimg.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hpimg.fillAmount==0)
        {
            FaildWin.SetActive(true);
        }
    }


    public void SetPlayerHp(float value)
    {
        
        Hpimg.fillAmount -= +value;
        if (Hpimg.fillAmount<=0)
        {
            Hpimg.fillAmount = 0;
        }
    }
}
