using UnityEngine;

public class JumperController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private int jumperPower;
  
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            SoundManager.Instance.PlaySFX(SoundManager.Sounds.jumperlong);
            PlayerController playerController=collision.GetComponent<PlayerController>();
            playerController.rb2d.velocity= new Vector2 (0,1)*jumperPower;
        }
    }
}
