using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }
    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>()!=null) {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
