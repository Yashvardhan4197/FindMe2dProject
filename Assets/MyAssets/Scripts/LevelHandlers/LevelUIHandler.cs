using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUIHandler : MonoBehaviour
{
    [SerializeField] Button level1;
    [SerializeField] Button level2;
    [SerializeField] Button level3;

    [SerializeField] Button goBack;

    [SerializeField] Color locked;
    [SerializeField] Color normal;
    [SerializeField] Color completed;


    private void Awake()
    {
        
    }
    void Start()
    {
        level1.onClick.AddListener(GoToLevel1);
        level2.onClick.AddListener(GoToLevel2);
        level3.onClick.AddListener(GoToLevel3);


        //Check or change Colors
        goBack.onClick.AddListener(GobackToLobby);


        //Set UI
        for (int i = 0; i < 3; i++)
        {
            if (LevelManager.Instance.getLevelStatus(LevelManager.Instance.Levels[i]) == LevelStatus.locked)
            {
                if (i == 0)
                {
                    ColorBlock colorBlock = level1.colors;
                    colorBlock.highlightedColor = locked;
                    colorBlock.selectedColor = locked;
                    level1.colors = colorBlock;
                }
                if (i == 1)
                {
                    ColorBlock colorBlock = level2.colors;
                    colorBlock.highlightedColor = locked;
                    colorBlock.selectedColor = locked;
                    level2.colors = colorBlock;
                }
                if (i == 2)
                {
                    ColorBlock colorBlock = level3.colors;
                    colorBlock.highlightedColor = locked;
                    colorBlock.selectedColor = locked;
                    level3.colors = colorBlock;
                }
            }
            if (LevelManager.Instance.getLevelStatus(LevelManager.Instance.Levels[i]) == LevelStatus.unlocked)
            {
                if (i == 0)
                {
                    ColorBlock colorBlock = level1.colors;
                    colorBlock.highlightedColor = normal;
                    colorBlock.selectedColor = normal;
                    level1.colors = colorBlock;
                }
                if (i == 1)
                {
                    ColorBlock colorBlock = level2.colors;
                    colorBlock.highlightedColor = normal;
                    colorBlock.selectedColor = normal;
                    level2.colors = colorBlock;
                }
                if (i == 2)
                {
                    ColorBlock colorBlock = level3.colors;
                    colorBlock.highlightedColor = normal;
                    colorBlock.selectedColor = normal;
                    level3.colors = colorBlock;
                }
            }
            if (LevelManager.Instance.getLevelStatus(LevelManager.Instance.Levels[i]) == LevelStatus.completed)
            {
                if (i == 0)
                {
                    ColorBlock colorBlock = level1.colors;
                    colorBlock.normalColor = completed;
                    colorBlock.selectedColor = completed;
                    colorBlock.highlightedColor = normal;
                    level1.colors = colorBlock;
                }
                if (i == 1)
                {
                    ColorBlock colorBlock = level2.colors;
                    colorBlock.normalColor = completed;
                    colorBlock.highlightedColor = normal;
                    colorBlock.selectedColor = completed;
                    level2.colors = colorBlock;
                }
                if (i == 2)
                {
                    ColorBlock colorBlock = level3.colors;
                    colorBlock.normalColor = completed;
                    colorBlock.highlightedColor = normal;
                    colorBlock.selectedColor = completed;
                    level3.colors = colorBlock;
                }
            }
        }
    }

    private void GobackToLobby()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Sounds.buttonSelect);
        gameObject.SetActive(false);
    }


    private void GoToLevel1()
    {
        if (LevelManager.Instance.getLevelStatus(LevelManager.Instance.Levels[0])==LevelStatus.completed|| LevelManager.Instance.getLevelStatus(LevelManager.Instance.Levels[0]) == LevelStatus.unlocked)
        {
            SoundManager.Instance.PlaySFX(SoundManager.Sounds.buttonSelect);
            SceneManager.LoadScene(1);
        }
        else
        {
            SoundManager.Instance.PlaySFX(SoundManager.Sounds.blockedPath);
        }
        
    }
    private void GoToLevel2()
    {
        if (LevelManager.Instance.getLevelStatus(LevelManager.Instance.Levels[1]) == LevelStatus.completed || LevelManager.Instance.getLevelStatus(LevelManager.Instance.Levels[1]) == LevelStatus.unlocked)
        {
            SoundManager.Instance.PlaySFX(SoundManager.Sounds.buttonSelect);
            SceneManager.LoadScene(2);
        }
        else
        {
            SoundManager.Instance.PlaySFX(SoundManager.Sounds.blockedPath);
        }

    }
    private void GoToLevel3()
    {

        if (LevelManager.Instance.getLevelStatus(LevelManager.Instance.Levels[2]) == LevelStatus.completed || LevelManager.Instance.getLevelStatus(LevelManager.Instance.Levels[2]) == LevelStatus.unlocked)
        {
            SoundManager.Instance.PlaySFX(SoundManager.Sounds.buttonSelect);
            SceneManager.LoadScene(3);
        }
        else
        {
            SoundManager.Instance.PlaySFX(SoundManager.Sounds.blockedPath);
        }
    }
}
