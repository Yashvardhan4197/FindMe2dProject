using UnityEngine;
using UnityEngine.UI;

public class TutorialTabController : MonoBehaviour
{
    [SerializeField] Button GoBack;

    private void Start()
    {
        GoBack.onClick.AddListener(GoBackToTab);
    }

    private void GoBackToTab()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Sounds.buttonSelect);
        gameObject.SetActive(false);
    }
}
