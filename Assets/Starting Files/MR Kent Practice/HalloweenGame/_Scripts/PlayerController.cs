using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ScoreKeeper scorekeeper;
    public bool player01, player02;
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

    public void GetPlayerMoveInput(int playerNumber)
    {
        if(playerNumber==1)
        {
             if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                //Debug.Log("W was pressed");
                yval = 1.0f;
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                //Debug.Log("s was pressed");
                yval = -1.0f;
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button2))
            {
                //Debug.Log("a was pressed");
                xval = -1.0f;
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button3))
            {
                //Debug.Log("d was pressed");
                xval = 1.0f;
            }
            
            if(Input.GetKeyUp(KeyCode.Joystick1Button0))
            {
                Debug.Log("W was released");
                yval = 0.0f;
            }
            if(Input.GetKeyUp(KeyCode.Joystick1Button1))
            {
                Debug.Log("s was released");
                yval = 0.0f;
            }
            if(Input.GetKeyUp(KeyCode.Joystick1Button2))
            {
                Debug.Log("a was released");
                xval = 0.0f;
            }
            if(Input.GetKeyUp(KeyCode.Joystick1Button3))
            {
                Debug.Log("d was released");
                xval = 0.0f;
            }
            /*
            if (Input.GetKeyDown("w"))
            {
                //Debug.Log("W was pressed");
                yval = 1.0f;
            }
            if (Input.GetKeyDown("s"))
            {
                //Debug.Log("s was pressed");
                yval = -1.0f;
            }
            if (Input.GetKeyDown("a"))
            {
                //Debug.Log("a was pressed");
                xval = -1.0f;
            }
            if (Input.GetKeyDown("f"))
            {
                //Debug.Log("d was pressed");
                xval = 1.0f;
            }
            
            if(Input.GetKeyUp("w"))
            {
                Debug.Log("W was released");
                yval = 0.0f;
            }
            if(Input.GetKeyUp("s"))
            {
                Debug.Log("s was released");
                yval = 0.0f;
            }
            if(Input.GetKeyUp("a"))
            {
                Debug.Log("a was released");
                xval = 0.0f;
            }
            if(Input.GetKeyUp("f"))
            {
                Debug.Log("d was released");
                xval = 0.0f;
            }
            */
        }
        else if(playerNumber ==2)
        {

             if (Input.GetKeyDown(KeyCode.Joystick2Button0))
            {
                Debug.Log("UpArrow was pressed");
                yval = 1.0f;
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button1))
            {
                Debug.Log("DownArrow was pressed");
                yval = -1.0f;
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button2))
            {
                Debug.Log("LeftArrow was pressed");
                xval = -1.0f;
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button3))
            {
                Debug.Log("RightArrow was pressed");
                xval = 1.0f;
            }
            
            if(Input.GetKeyUp(KeyCode.Joystick2Button0))
            {
                Debug.Log("UpArrow was released");
                yval = 0.0f;
            }
            if(Input.GetKeyUp(KeyCode.Joystick2Button1))
            {
                Debug.Log("DownArrow was released");
                yval = 0.0f;
            }
            if(Input.GetKeyUp(KeyCode.Joystick2Button2))
            {
                Debug.Log("LeftArrow was released");
                xval = 0.0f;
            }
            if(Input.GetKeyUp(KeyCode.Joystick2Button3))
            {
                Debug.Log("RightArrow was released");
                xval = 0.0f;
            } 
            /*
            
             if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("UpArrow was pressed");
                yval = 1.0f;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("DownArrow was pressed");
                yval = -1.0f;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("LeftArrow was pressed");
                xval = -1.0f;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("RightArrow was pressed");
                xval = 1.0f;
            }
            
            if(Input.GetKeyUp(KeyCode.UpArrow))
            {
                Debug.Log("UpArrow was released");
                yval = 0.0f;
            }
            if(Input.GetKeyUp(KeyCode.DownArrow))
            {
                Debug.Log("DownArrow was released");
                yval = 0.0f;
            }
            if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Debug.Log("LeftArrow was released");
                xval = 0.0f;
            }
            if(Input.GetKeyUp(KeyCode.RightArrow))
            {
                Debug.Log("RightArrow was released");
                xval = 0.0f;
            } 
            */

        }
    }

    public void GetPlayerFireInput(int playerNumber)
    {
        if(playerNumber==1)
        { 
            
            if(Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                Instantiate(shot, shotpoint.position, shotpoint.rotation);
                shotCounter = timeBetweenShots;
                scorekeeper.SubtractPointsPlayer01(1);
            }

            if (Input.GetKey(KeyCode.Joystick1Button1))
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
            /*
              
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(shot, shotpoint.position, shotpoint.rotation);
                shotCounter = timeBetweenShots;
                scorekeeper.SubtractPointsPlayer01(1);
            }

            if (Input.GetKey(KeyCode.Space))
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

            */

        }
        else if(playerNumber ==2)
        { 
            if(Input.GetKeyDown(KeyCode.Joystick2Button0))
            {
                Instantiate(shot, shotpoint.position, shotpoint.rotation);
                shotCounter = timeBetweenShots;
                 scorekeeper.SubtractPointsPlayer02(1);
            }

            if(Input.GetKey(KeyCode.Joystick2Button1))
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
            /*
                 if(Input.GetKeyDown(KeyCode.Return))
            {
                Instantiate(shot, shotpoint.position, shotpoint.rotation);
                shotCounter = timeBetweenShots;
                 scorekeeper.SubtractPointsPlayer02(1);
            }

            if(Input.GetKey(KeyCode.Return))
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
            */
        }
    }
}
