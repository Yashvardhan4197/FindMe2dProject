using System.Collections;
using UnityEditor.Tilemaps;
using UnityEngine;
using static ObjectController;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform startPosition;
    [SerializeField] HealthBarController healthBarController;
    [SerializeField] HealthController heartController;
    [SerializeField] GameObject pauseController;
    [SerializeField] int speed;
    [SerializeField] int jumpForce;
    [SerializeField] Transform JumpOverlapArea;
    [SerializeField] float radius;
    [SerializeField] LayerMask isGround;
    [HideInInspector]public Rigidbody2D rb2d;
    private int extraJump;
    private int extraJumpValues=3;


    [SerializeField] GameObject bulletBody;
    [SerializeField] float bulletDistance;
    [SerializeField] float bulletSpeed;
    private bool isPaused=false;
    private ObjectController objectController;
    private void Awake()
    {
        objectController = GetComponent<ObjectController>();
        GoToStartPosition();
        extraJump = extraJumpValues;
        rb2d = GetComponent<Rigidbody2D>();
        pauseController.SetActive(false);
        objectController.SetSize();
    }
    private void Start()
    {
        Time.timeScale = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        MovePlayer(horizontal);
        JumpPlayer();

        //ShapeChanger
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            objectController.currentSize = Objects.small;
            SoundManager.Instance.PlaySFX(SoundManager.Sounds.powers);
            SetPowers();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            objectController.currentSize = Objects.medium;
            SoundManager.Instance.PlaySFX(SoundManager.Sounds.powers);
            SetPowers();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            objectController.currentSize = Objects.large;
            SoundManager.Instance.PlaySFX(SoundManager.Sounds.powers);
            SetPowers();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
            SoundManager.Instance.PlaySFX(SoundManager.Sounds.pause);

        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (objectController.currentSize == Objects.medium)
            {
                StartCoroutine(sendBullet());
            }
        }
    }


    //Powers

    IEnumerator sendBullet()
    {

        float travelDistance = 0f;
        Transform bullet= Instantiate(bulletBody.transform);
        if (bullet != null) 
        {
        bullet.position = transform.position;
        int direction = 0;
        if(transform.localScale.x > 0f)
        {
            direction = 1;
        }
        else if(transform.localScale.x < 0f)
        {
            direction = -1;
        }
            while (travelDistance < bulletDistance)
            {

                float step = bulletSpeed * Time.deltaTime;
                travelDistance += step;
                if (bullet == null)
                {
                    break;
                }
                Vector3 bulletPos = bullet.position;
                Vector3 bulletRotate = bullet.localScale;
                if (direction == 1)
                {
                    bulletPos = new Vector3(bulletPos.x + step, bulletPos.y, 0);
                    bulletRotate = new Vector3(Mathf.Abs(bulletRotate.x), bulletRotate.y, 0);

                }
                else if (direction == -1)
                {
                    bulletPos = new Vector3(bulletPos.x - step, bulletPos.y, 0);
                    if (bulletRotate.x > 0f)
                    {
                        bulletRotate = new Vector3(Mathf.Abs(bulletRotate.x) * -1, bulletRotate.y, 0);
                    }
                }
                if (bullet == null)
                {
                    break;
                }
                bullet.position = bulletPos;
                bullet.localScale = bulletRotate;
                yield return null;
            }
            
        }
        if (bullet != null)
        {
            Destroy(bullet.gameObject);
        }
        
    }

    private void SetPowers()
    {
        if(objectController.currentSize == Objects.small)
        {
            rb2d.velocity = new Vector2(0f, 1f) * jumpForce;
            objectController.SetSize();
            extraJumpValues = 3;
        }
        if (objectController.currentSize == Objects.medium)
        {
            rb2d.velocity = new Vector2(0f, 1f) * jumpForce;
            objectController.SetSize();
            extraJumpValues = 2;
        }
        if(objectController.currentSize == Objects.large)
        {
            rb2d.velocity = new Vector2(0f, 1f) * jumpForce;
            objectController.SetSize();
            extraJumpValues = 0;
        }
    }



    private void MovePlayer(float horizontal)
    {
        Vector3 position= transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

        Vector3 setScale=transform.localScale;
        if (horizontal > 0)
        {
            setScale.x = Mathf.Abs(setScale.x);
        }
        if(horizontal < 0)
        {
            if (setScale.x > 0)
            {
                setScale.x = -1 * setScale.x;
            }
        }
        transform.localScale = setScale;
    }

    private void JumpPlayer()
    {
        bool onGround = Physics2D.OverlapCircle(JumpOverlapArea.position, radius, isGround);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround)
            {
                extraJump = extraJumpValues;
                
                
            }
            if(extraJump!=0)
            {
                rb2d.velocity = new Vector2(0, 1) * jumpForce;
                extraJump--;
            }
            else if(onGround==true&&extraJump<=0)
            {
                rb2d.velocity = new Vector2(0, 1) * jumpForce;
            }
            SoundManager.Instance.PlaySFX(SoundManager.Sounds.jump);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "OutSideGame")
        {
            transform.position = startPosition.position;
            heartController.decreaseHealth();
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            //healthBarController.playerOnSpike = true;
            //healthBarController.reduceHealthBar();
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            healthBarController.playerOnSpike = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            healthBarController.playerOnSpike = true;
            healthBarController.reduceHealthBar();
        }
    }


    //Pause Game
    private void PauseGame()
    {
        if (isPaused == false)
        {
            pauseController.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
            Debug.Log("Pause");
        }
        else if(isPaused == true)
        {
            pauseController.SetActive(false) ;
            Time.timeScale = 1f;
            isPaused = false;
        }
        
    }


    //Go To Start Position
    public void GoToStartPosition()
    {
        transform.localPosition = startPosition.position;
        
    }
}
