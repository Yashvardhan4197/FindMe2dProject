using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] int target;

    [SerializeField] HealthBarController healthBarController;
    [SerializeField] PlayerController playerController;
    [SerializeField] ObjectController objectController;
    // Start is called before the first frame up
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }
    private void MoveEnemy()
    {
        Vector3 pos=transform.position;
        Vector3 scale=transform.localScale;
        if (target==1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, speed*Time.deltaTime);
            if(Vector3.Distance(transform.position, patrolPoints[1].position)<2f)
            {
                target = 0;
            }
            scale.x = Mathf.Abs(scale.x);

        }
        else if (target==0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, patrolPoints[0].position) < 2f)
            {
                target = 1;
            }
            if (scale.x > 0)
            {
                scale.x=Mathf.Abs(scale.x)*-1;
            }
        }
        transform.localScale= scale;

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(gameObject);
        }
        if (objectController.currentSize != ObjectController.Objects.large)
        {
            if (collision.tag == "Player")
            {
                healthBarController.reduceHealthByEnemy(3);
                SoundManager.Instance.PlaySFX(SoundManager.Sounds.Damage);
                if (target == 1)
                {
                    playerController.rb2d.velocity = new Vector2(1, 0) * 5;
                }
                else
                {
                    playerController.rb2d.velocity = new Vector2(-1, 0) * 5;
                }
            }
        }


    }
   
}
