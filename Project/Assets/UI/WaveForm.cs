using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveForm : MonoBehaviour
{
    [SerializeField] private TMP_Text countDownText;
    [SerializeField] private TMP_Text waveNumberText;
    [SerializeField] private CanvasGroup container;

    private bool isCountingDown;
    private float countDownTimer;

    [Header("Value")]
    public float overTime;
    
    private void Awake()
    {
        waveManager.OnNewWave += OnNewWave;
    }
    private void Start()
    {
        StartCoroutine(IEwaitTime());
    }
    private void OnNewWave()
    {
        isCountingDown = true;
        countDownTimer = waveManager.timeBetweenWaves;

        countDownText.alpha = 1;
        waveNumberText.SetText(waveManager.waveNumber.ToString());
    }

    private void Update()
    {
        if (!isCountingDown)
        {
            return;
        }

        /*countDownTimer -= Time.deltaTime;
        countDownText.gameObject.SetActive(countDownTimer > 0.1f);

        if (countDownTimer % 1 > 0.5f)
        {
            countDownText.alpha -= Time.deltaTime * 2;
        }
        else
        {
            countDownText.alpha += Time.deltaTime * 2;
        }

        if(countDownTimer < waveManager.timeBetweenWaves * 0.5f)
        {
            container.alpha += Time.deltaTime * 0.5f;
        }

        if(countDownTimer < 0.1f)
        {
            isCountingDown = false;
            container.alpha = 0;
        }
        else
        {
             //countDownText.SetText(sourceText: Mathf.Round(countDownTimer).ToString);
        }*/
        
    }

    private void OnDestory()
    {
        waveManager.OnNewWave -= OnNewWave;
    }
    public IEnumerator IEwaitTime()
    {
        float current = 0;
        float cH = 0;
        while(current<overTime)
        {
            current += 0.01f;
            countDownText.text = ((int)(overTime - current) + 1).ToString();
            cH = current % 1;
            countDownText.color = new Color(countDownText.color.r, countDownText.color.g, countDownText.color.b, 1 - cH);
            yield return new WaitForSeconds(0.01f);
        }
        gameObject.SetActive(false);
    }
}
