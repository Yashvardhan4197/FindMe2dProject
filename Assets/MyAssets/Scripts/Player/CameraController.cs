using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Speed = 2f;
    public float xOffset;
    public float yOffset;
    [SerializeField] Transform playerTransform; 
    void Update()
    {
        Vector3 newPos = new Vector3(playerTransform.position.x+xOffset, playerTransform.position.y+yOffset, -10);
        transform.position = Vector3.Slerp(transform.position, newPos, Speed * Time.deltaTime);
    }
}
