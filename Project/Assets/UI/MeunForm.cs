using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MeunForm : MonoBehaviour
{
    [SerializeField] private GameObject masks;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        masks.SetActive(false);

        menuButton.onClick.AddListener(OnMenuButtonClick);
        restartButton.onClick.AddListener(OnRestartButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);
    }

    private  void OnEnable()
    {
        //GameEvents.GameOver += GameOver;
    }


    private void OnMenuButtonClick() {
        // change scene
        SceneManager.LoadScene("Menu");
    }
    private void OnRestartButtonClick() {
        SceneManager.LoadScene("Game");
    }
    private void OnQuitButtonClick() {
        Application.Quit();
#if UNITY_EDITOR
       UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    private void GameOver() { }

    private void OnDisable()
    {
        //GameEvents.GameOver -= GameOver;
    }

}
