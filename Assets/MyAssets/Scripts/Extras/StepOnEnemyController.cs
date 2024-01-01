using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StepOnEnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ObjectController objectController;
    [SerializeField] GameObject enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (objectController.currentSize == ObjectController.Objects.large)
            {
                Destroy(enemy);
                SoundManager.Instance.PlaySFX(SoundManager.Sounds.shoot);
            }
        }
    }
}
