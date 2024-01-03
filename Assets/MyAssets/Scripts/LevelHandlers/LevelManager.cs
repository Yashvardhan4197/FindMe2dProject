using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    [SerializeField] public string[] Levels;

    private void Awake()
    {
        
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (getLevelStatus(Levels[0]) == LevelStatus.locked)
        {
            setLevelStatus(Levels[0], LevelStatus.unlocked);
            
        }
    }


    public LevelStatus getLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    public void setLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }


    void Update()
    {
        
    }

    public void MarkCompleted(string levelName)
    {
        setLevelStatus(levelName, LevelStatus.completed);
    }

    
}
