using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using UnityEngine;



public class ChangeSpartanBeanAnimation : MonoBehaviour
{
    [SerializeField] private float moveSpeed =10f;
    
    private Rigidbody2D rb = null;
    private Vector2 moveVector = Vector2.zero;
    private Animator animator = null;

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }


    private void OnEnable()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log("Entering Update");
        MovePerformed();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = moveVector*moveSpeed;
        Debug.Log(moveVector*moveSpeed  );
    }

    private void MovePerformed()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.localScale = Vector3.one;
            moveVector = new Vector2(1f, 0f);
            animator.SetBool("isWalking", true);

        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            moveVector = Vector2.zero;
            animator.SetBool("isWalking", false);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            moveVector = new Vector2(-1f, 0f);
            animator.SetBool("isWalking", true);

        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            moveVector = Vector2.zero;
            animator.SetBool("isWalking", false);
        }

    }
}
