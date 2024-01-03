using UnityEngine;

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
        currentSize = Objects.small;
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    currentSize = Objects.small;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    currentSize = Objects.medium;
        //}
        //if(Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    currentSize = Objects.large;
        //}
    }

    

    public void SetSize()
    {
        BoxCollider2D existingCollider=gameObject.GetComponent<BoxCollider2D>();
        if (existingCollider != null)
        {
            DestroyImmediate(GetComponent<BoxCollider2D>());
        }
        switch (currentSize)
        {
            case Objects.small:
                {
                    transform.localScale = SmallObject;
                    break;
                }
            case Objects.medium:
                {
                    transform.localScale = MediumObject;
                        break;
                }
            case Objects.large:
                {
                    transform.localScale = LargeObject;
                    break;
                }
        }

          gameObject.AddComponent<BoxCollider2D>();
        
    }

}
