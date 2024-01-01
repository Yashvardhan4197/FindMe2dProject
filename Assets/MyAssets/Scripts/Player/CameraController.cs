using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 2f;
    public float xOffset;
    public float yOffset;
    [SerializeField] Transform playerTransform; 

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(playerTransform.position.x+xOffset, playerTransform.position.y+yOffset, -10);
        transform.position = Vector3.Slerp(transform.position, newPos, Speed * Time.deltaTime);
    }
}
