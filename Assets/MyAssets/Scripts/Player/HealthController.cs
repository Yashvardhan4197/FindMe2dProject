using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] GameObject[] sprites;
    private int health;
    private int maxHealth = 3;
    void Start()
    {
        health = 3;
        for(int i = 0; i < sprites.Length; i++)
        {
            sprites[i].SetActive(false);
        }
        RefreshUI();
    }


    private void RefreshUI()
    {
        for(int i = 0;i<health;i++)
        {
            sprites[i].SetActive(true);
        }
        for(int i = health; i < maxHealth; i++)
        {
            sprites[i].SetActive(false);
        }
    }
    public void decreaseHealth()
    {
        health--;
        RefreshUI();
        SoundManager.Instance.PlaySFX(SoundManager.Sounds.PlayerDeath);
    }
    public void GainHealth()
    {
        health++;
        RefreshUI();
    }

    public int GetHealth()
    {
        return health;
    }
}
