using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameUIController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] HealthController healthController;
    [SerializeField] GameObject DeadGameScreen;
    void Start()
    {
        DeadGameScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
    }

    private void CheckHealth()
    {
        if(healthController.GetHealth() <= 0)
        {
            EndGameNow();
        }
    }
    private void EndGameNow()
    {
        Time.timeScale = 0f;
        DeadGameScreen.SetActive(true);
    }
}
