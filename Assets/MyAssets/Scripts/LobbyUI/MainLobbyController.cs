using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLobbyController : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button HowtoPlay;
    [SerializeField] GameObject levelsTab;
    [SerializeField] GameObject tutorialTab;

    private void Start()
    {
        levelsTab.SetActive(false);
        tutorialTab.SetActive(false);
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
        HowtoPlay.onClick.AddListener(OpenTut);
    }

    private void OpenTut()
    {
        tutorialTab.SetActive(true);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        levelsTab.SetActive(true);
    }
}
