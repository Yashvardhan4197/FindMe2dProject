using UnityEngine;

public class StepOnEnemyController : MonoBehaviour
{
    [SerializeField] ObjectController objectController;
    [SerializeField] GameObject enemy;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            if (objectController.currentSize == ObjectController.Objects.large)
            {
                Destroy(enemy);
                SoundManager.Instance.PlaySFX(SoundManager.Sounds.shoot);
            }
        }
    }
}
