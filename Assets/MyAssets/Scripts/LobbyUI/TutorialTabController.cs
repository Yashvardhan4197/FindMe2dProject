using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTabController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button GoBack;

    private void Start()
    {
        GoBack.onClick.AddListener(GoBackToTab);
    }

    private void GoBackToTab()
    {
        gameObject.SetActive(false);
    }
}
