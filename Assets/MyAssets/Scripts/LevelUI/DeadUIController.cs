using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadUIController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button restartButton;
    [SerializeField] Button exitButton;
    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
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
