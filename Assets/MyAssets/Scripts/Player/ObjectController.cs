using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectController : MonoBehaviour
{
    [HideInInspector]public Objects currentSize=Objects.medium;
    [SerializeField] Vector3 SmallObject;
    [SerializeField] Vector3 MediumObject;
    [SerializeField] Vector3 LargeObject;
    public enum Objects
    {
        medium,
        small,
        large
    }

    private void Awake()
    {
        currentSize = Objects.medium;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSize = Objects.small;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSize = Objects.medium;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSize = Objects.large;
        }
    }

    

    public void SetSize()
    {
        Destroy(GetComponent<BoxCollider2D>());

        switch (currentSize)
        {
            case Objects.small:
                {
                    transform.localScale = SmallObject;
                    gameObject.AddComponent<BoxCollider2D>();
                    break;
                }
            case Objects.medium:
                {
                    transform.localScale = MediumObject;
                    gameObject.AddComponent<BoxCollider2D>();
                        break;
                }
            case Objects.large:
                {
                    transform.localScale = LargeObject;
                    gameObject.AddComponent<BoxCollider2D>();
                    break;
                }
        }
    }
}
