using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player") {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
