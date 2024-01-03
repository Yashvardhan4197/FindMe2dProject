using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() == null)
        {
            Destroy(gameObject);
            SoundManager.Instance.PlaySFX(SoundManager.Sounds.shoot);
;        }
    }
}
