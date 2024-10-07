using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpartanBeanController : MonoBehaviour
{
    [SerializeField] private float moveSpeed =10f;
    private Rigidbody2D rb = null;
    private Vector2 moveVector = Vector2.zero;
    private Animator animator = null;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePerformed();
    }

    void FixedUpdate()
    {
        rb.velocity = moveVector*moveSpeed;
        //Debug.Log(moveVector*moveSpeed  );

    }

    private void MovePerformed()
    {
        if(Input.GetKey(KeyCode.D))
        {
        // move right
            transform.localScale = Vector3.one;
            moveVector = new Vector2(1f,0f);
            animator.SetBool("isWalking", true);
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            //key released
            moveVector = Vector2.zero;
            animator.SetBool("isWalking", false);
        }

        if(Input.GetKey(KeyCode.A))
        {
            // move Left
            transform.localScale = new Vector3(-1f,1f,1f);
            moveVector = new Vector2(-1f,0f);
            animator.SetBool("isWalking", true);
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            //key released
            moveVector = Vector2.zero;
            animator.SetBool("isWalking", false);
        }


    }
}
