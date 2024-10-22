using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealthSystem : MonoBehaviour
{

    public bool player01, player02, player03, player04;
    public int playerHealth;
    public int playerFullHealth;
    //
    //PlayerParts
    public SpriteRenderer playerSprite;
    public PlayerController playerControlScript;
    public CircleCollider2D playerCircleCollider;
    public PolygonCollider2D playerPolygonCollider;
    public GameObject playerChildGO1;
    public GameObject playerChildGO2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetPlayer();
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerTakeDamage();
        }
    }
    public void PlayerTakeDamage()
    {
        //take damage
        playerHealth = playerHealth - 1;
        if(playerHealth<=0)
        {
            //deactivate player
            DeactivatePlayer();
        }

    }

    public void ResetPlayer()
    {
        //reset the player
        playerHealth = playerFullHealth;

        playerSprite.enabled = true;
        playerControlScript.enabled = true;
        playerCircleCollider.enabled = true;
        playerPolygonCollider.enabled = true;
        playerChildGO1.SetActive(true);
        playerChildGO2.SetActive(true);


    }

    public void DeactivatePlayer()
    {
        //reset the player
        playerSprite.enabled = false;
        playerControlScript.enabled = false;
        playerCircleCollider.enabled = false;
        playerPolygonCollider.enabled = false;
        playerChildGO1.SetActive(false);
        playerChildGO2.SetActive(false);
    }
}
