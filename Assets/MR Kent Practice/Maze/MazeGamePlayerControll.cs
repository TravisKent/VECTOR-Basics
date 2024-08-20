using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGamePlayerControll : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    [SerializeField]
    private float speed = 8f;
    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
         
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
 
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, vertical*speed);
    }

     
}
