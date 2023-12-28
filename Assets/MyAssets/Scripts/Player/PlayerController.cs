using UnityEngine;
using static ObjectController;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform startPosition;

    [SerializeField] int speed;
    [SerializeField] int jumpForce;
    [SerializeField] Transform JumpOverlapArea;
    [SerializeField] float radius;
    [SerializeField] LayerMask isGround;
    private Rigidbody2D rb2d;
    private int extraJump;
    private int extraJumpValues=2;

    private ObjectController objectController;
    private void Awake()
    {
        objectController = GetComponent<ObjectController>();
        transform.localPosition = startPosition.position;
        extraJump = extraJumpValues;
        rb2d = GetComponent<Rigidbody2D>();

        objectController.SetSize();
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
            SetPowers();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            objectController.currentSize = Objects.medium;
            SetPowers();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            objectController.currentSize = Objects.large;
            SetPowers();
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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "OutSideGame")
        {
            transform.position = startPosition.position;
        }
    }


}
