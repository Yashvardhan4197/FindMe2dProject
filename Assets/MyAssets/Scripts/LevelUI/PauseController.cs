using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button exitButton;

    private void Start()
    {
        restartButton.onClick.AddListener(RestartTheGame);
        exitButton.onClick.AddListener(ExitTheGame);
    }

    private void RestartTheGame()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Sounds.buttonSelect);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void ExitTheGame()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Sounds.buttonSelect);
        SceneManager.LoadScene(0);
    }
}
