using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>()!=null)
        {
            SoundManager.Instance.PlaySFX(SoundManager.Sounds.LevelComplete);
            LevelManager.Instance.setLevelStatus(SceneManager.GetActiveScene().name, LevelStatus.completed);
            Debug.Log(LevelManager.Instance.getLevelStatus(SceneManager.GetActiveScene().name));
            if (SceneManager.GetActiveScene().buildIndex < LevelManager.Instance.Levels.Length)
            {
                LevelManager.Instance.setLevelStatus(LevelManager.Instance.Levels[SceneManager.GetActiveScene().buildIndex], LevelStatus.unlocked);
                
            }
            if (SceneManager.GetActiveScene().buildIndex < LevelManager.Instance.Levels.Length)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            
        }
    }
}
