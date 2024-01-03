using UnityEngine;

public class blockDestroyer : MonoBehaviour
{
    [SerializeField] GameObject block;
    [SerializeField] Vector3 newScale;
    public void blockDestroy()
    {
        Destroy(block);
        transform.localScale = newScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.GetComponent<PlayerController>() != null)
       {
            blockDestroy();
            SoundManager.Instance.PlaySFX(SoundManager.Sounds.blockedPath);
        }
    }
}
