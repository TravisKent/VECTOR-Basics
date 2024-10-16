using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ScoreKeeper scorekeeper;
    public bool player01, player02, player03, player04;
    private float yval, xval;
     Vector2 InputAxes;

    public float moveSpeed;
    public Rigidbody2D theRB;

    public Transform bottomLeftLimit, topRightLimit;

    public Transform shotpoint;
    public GameObject shot;
    private float shotCounter;
    public float timeBetweenShots = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        scorekeeper = GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
       // theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))*moveSpeed;
        
        
        if(player01==true)
        {
            //GetPlayerMoveInput(1);
          //  Debug.Log("Moving player 1 JS");
            InputAxes.x = Input.GetAxisRaw ("Horizontal1");
            InputAxes.y = Input.GetAxisRaw ("Vertical1");
            Debug.Log(InputAxes);
        
            theRB.velocity = new Vector2(InputAxes.x, InputAxes.y)*moveSpeed;
            transform.position = new Vector3( Mathf.Clamp(transform.position.x, bottomLeftLimit.position.x, topRightLimit.position.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.position.y, topRightLimit.position.y),  transform.position.z);

        }
        else if(player02 == true)
        {
            //GetPlayerMoveInput(2);
           
            InputAxes.x = Input.GetAxisRaw ("Horizontal2");
            InputAxes.y = Input.GetAxisRaw ("Vertical2");
             theRB.velocity = new Vector2(InputAxes.x, InputAxes.y)*moveSpeed;
            transform.position = new Vector3( Mathf.Clamp(transform.position.x, bottomLeftLimit.position.x, topRightLimit.position.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.position.y, topRightLimit.position.y),  transform.position.z);

        }
        else
        {
            Debug.Log("No Player Was Selected");
        }


      //  theRB.velocity = new Vector2(xval, yval)*moveSpeed;
         
       // transform.position = new Vector3( Mathf.Clamp(transform.position.x, bottomLeftLimit.position.x, topRightLimit.position.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.position.y, topRightLimit.position.y),  transform.position.z);

        
        if(player01==true)
        {
           GetPlayerFireInput(1);
           
        }
        else if(player02 == true)
        {
            GetPlayerFireInput(2);
           
        }
        else
        {
            Debug.Log("No Player Was Selected");
        }

    }

    

    public void GetPlayerFireInput(int playerNumber)
    {
        if(playerNumber==1)
        { 
            
            if(Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.LeftControl))
            {
                Instantiate(shot, shotpoint.position, shotpoint.rotation);
                shotCounter = timeBetweenShots;
                scorekeeper.SubtractPointsPlayer01(1);
            }

            if (Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.LeftControl))
            {
            // Instantiate(shot, shotpoint.position, shotpoint.rotation);
                shotCounter -= Time.deltaTime;
                if(shotCounter <=0)
                {
                    Instantiate(shot, shotpoint.position, shotpoint.rotation);
                    shotCounter = timeBetweenShots;
                    scorekeeper.SubtractPointsPlayer01(1);
                }
            }
            

        }
        else if(playerNumber ==2)
        { 
            if(Input.GetKeyDown(KeyCode.Joystick2Button0) || Input.GetKeyDown(KeyCode.RightControl))
            {
                Instantiate(shot, shotpoint.position, shotpoint.rotation);
                shotCounter = timeBetweenShots;
                 scorekeeper.SubtractPointsPlayer02(1);
            }

            if(Input.GetKey(KeyCode.Joystick2Button0) || Input.GetKey(KeyCode.RightControl))
            {
            // Instantiate(shot, shotpoint.position, shotpoint.rotation);
                shotCounter -= Time.deltaTime;
                if(shotCounter <=0)
                {
                    Instantiate(shot, shotpoint.position, shotpoint.rotation);
                    shotCounter = timeBetweenShots;
                     scorekeeper.SubtractPointsPlayer02(1);
                }
            }
           
        }
    }
}
