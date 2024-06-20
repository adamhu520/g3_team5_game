using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeunForm : MonoBehaviour
{
    //T0D0 Tween
    [SerializeField] private GameObject masks;
    [SerializeField] private Button meunButton;
    [SerializeField] private Button restartButtin;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        masks.SetActive(false);

        meunButton.onClick.AddListener(OnMenuButtonClick);
        restartButtin.onClick.AddListener(OnRestartButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);
    }

    private void OnEnable()
    {
        GameEvents.GameOver += GameOver;
    }

    private void OnMenuButtonClick() {
        // change scene
        SceneManager.LoadScence("Meun");
    }

    private void OnRestartButtonClick() {
        SceneManager.LoadScence("Game");
    }

    private void OnQuitButtonClick() {
        Application.Quit;
#if UNITY_EDITOR
        unityEditor.EditorApplication.isPlaying = false;
#endif  
    }
    private void GameOver() { }

    private void OnDisable()
    {
        GameEvents.GameOver -= GameOver;
    }


}
