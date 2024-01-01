using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{

    [SerializeField] HealthController heartController;
    [SerializeField] PlayerController playerController;
    [SerializeField] Slider healthSlider;
    [SerializeField] float maxhealthSlide;
    private float healthOnSlide;
    [SerializeField] float reductionRate;
    [HideInInspector]public bool playerOnSpike = false;
    void Start()
    {
        healthSlider.maxValue = maxhealthSlide;
        healthOnSlide = maxhealthSlide;
        UpdateHealthSlider();
    }

    // Update is called once per frame
    void Update()
    {
        //if(playerOnSpike)
        //{
        //    reduceHealthBar();
        //}
    }

    private void UpdateHealthSlider()
    {
        healthSlider.value = healthOnSlide;
    }
    public void reduceHealthBar()
    {
        healthOnSlide-=reductionRate*Time.deltaTime;
        UpdateHealthSlider();
        if(healthOnSlide <= 0)
        {
            healthOnSlide = maxhealthSlide;
            UpdateHealthSlider();
            heartController.decreaseHealth();
            playerController.GoToStartPosition();
        }

    }
    public void reduceHealthByEnemy(int value)
    {
        healthOnSlide -= value;
        UpdateHealthSlider();
        if (healthOnSlide <= 0)
        {
            heartController.decreaseHealth();
            playerController.GoToStartPosition();
            healthOnSlide = maxhealthSlide;
            UpdateHealthSlider();
        }
    }
    
}
