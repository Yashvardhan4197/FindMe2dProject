using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] int target;
    [SerializeField] int recoilOnPlayer;
    [SerializeField] int reduceHealth;
    [SerializeField] HealthBarController healthBarController;
    [SerializeField] PlayerController playerController;
    [SerializeField] ObjectController objectController;
    
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
        if (collision.GetComponent<BulletCollision>() != null)
        {
            Destroy(gameObject);
        }
        if (objectController.currentSize != ObjectController.Objects.large)
        {
            if (collision.GetComponent<PlayerController>() != null)
            {
                healthBarController.reduceHealthByEnemy(reduceHealth);
                SoundManager.Instance.PlaySFX(SoundManager.Sounds.Damage);
                if (target == 1)
                {
                    playerController.rb2d.velocity = new Vector2(1, 0) * recoilOnPlayer;
                }
                else
                {
                    playerController.rb2d.velocity = new Vector2(-1, 0) * recoilOnPlayer;
                }
            }
        }


    }
   
}
