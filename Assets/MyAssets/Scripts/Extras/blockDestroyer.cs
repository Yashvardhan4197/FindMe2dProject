using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject block;
    public void blockDestroy()
    {
        Destroy(block);
        Vector3 newScale = new Vector3(0.37f, 0.57f,0f);
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
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.GetComponent<PlayerController>() != null) { blockDestroy(); }
    //}
}
