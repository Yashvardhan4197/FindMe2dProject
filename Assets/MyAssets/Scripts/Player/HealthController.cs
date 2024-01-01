using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
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
