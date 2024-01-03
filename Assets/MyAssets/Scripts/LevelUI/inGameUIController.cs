using UnityEngine;

public class inGameUIController : MonoBehaviour
{
    [SerializeField] HealthController healthController;
    [SerializeField] GameObject DeadGameScreen;
    void Start()
    {
        DeadGameScreen.SetActive(false);
    }
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
