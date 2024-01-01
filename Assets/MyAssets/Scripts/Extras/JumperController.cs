using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    [SerializeField] private int jumperPower;
    private void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
