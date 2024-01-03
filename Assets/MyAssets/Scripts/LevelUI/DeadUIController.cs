using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadUIController : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button exitButton;
    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void RestartGame()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Sounds.buttonSelect);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    private void ExitGame()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Sounds.buttonSelect);
        SceneManager.LoadScene(0);
    }
}
