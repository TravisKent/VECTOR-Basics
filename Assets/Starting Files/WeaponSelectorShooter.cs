using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectorShooter : MonoBehaviour
{
    public bool player1, player2; 
    public GameObject[] PlayerWeaponsList;
    public Transform[] barrelEndlist;
    public GameObject[] BulletList;
    public int Selected;
    public KeyCode p1NextWeapon, p2NextWeapon;
    public KeyCode p1BulletFired, p2BulletFired;

    public ScoreKeeper myScore;

    // Start is called before the first frame update
    void Start()
    {
        myScore = GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
       UpdateWeaponSelected();
       
       SpawnBulletAndDecreaseScore();
    }


    public void UpdateWeaponSelected()
    {
         //if(Input.GetKeyDown(KeyCode.J))
        if(Input.GetKeyDown(p1NextWeapon) && player1)
        {
            
            Selected++;
            if(Selected >= PlayerWeaponsList.Length )
            {
                Selected=0;
            }
            for(int i=0; i < PlayerWeaponsList.Length; i++)
            {
                //Debug.Log(i);
                if(i ==Selected)
                {
                    PlayerWeaponsList[i].SetActive(true);
                }
                else
                {
                    PlayerWeaponsList[i].SetActive(false);
                }
            }

            if(player1)
            {
                
                if(Selected == 1 && (myScore.numbPlayer01Score > 50) )
                {
                    
                    myScore.SubtractPointsPlayer01(50);
                }
                else if(Selected == 2 && (myScore.numbPlayer01Score > 100) )
                {
                    
                    myScore.SubtractPointsPlayer01(50);
                }
                else if(Selected == 3 && (myScore.numbPlayer01Score > 200) )
                {
                    
                    myScore.SubtractPointsPlayer01(50);
                }
                else if(Selected == 4 && (myScore.numbPlayer01Score > 400 ))
                {
                    
                    myScore.SubtractPointsPlayer01(150);
                }
                else if(Selected == 5 && (myScore.numbPlayer01Score > 800 ))
                {
                    
                    myScore.SubtractPointsPlayer01(200);
                }
                else 
                {
                    Selected=0;
                    for(int i=0; i < PlayerWeaponsList.Length; i++)
                    {
                        //Debug.Log(i);
                        if(i ==Selected)
                        {
                            PlayerWeaponsList[i].SetActive(true);
                        }
                        else
                        {
                            PlayerWeaponsList[i].SetActive(false);
                        }
                    }
                }
            
            /*
                if(Selected == 3 && myScore.numbPlayer01Score > 200 )
                {
                    
                    myScore.SubtractPointsPlayer01(50);
                }
                else 
                {
                    Selected=0;
                }

                if(Selected == 4 && myScore.numbPlayer01Score > 400 )
                {
                    
                    myScore.SubtractPointsPlayer01(150);
                }
                else 
                {
                    Selected=0;
                }

                if(Selected == 5 && myScore.numbPlayer01Score > 800 )
                {
                    
                    myScore.SubtractPointsPlayer01(200);
                }
                else 
                {
                    Selected=0;
                }

                */
           
            }

           
        }
         //if(Input.GetKeyDown(KeyCode.J))
        else if(Input.GetKeyDown(p2NextWeapon) && player2)
        {
            
            Selected++;
            if(Selected >= PlayerWeaponsList.Length )
            {
                Selected=0;
            }
            for(int i=0; i < PlayerWeaponsList.Length; i++)
            {
                //Debug.Log(i);
                if(i ==Selected)
                {
                    PlayerWeaponsList[i].SetActive(true);
                }
                else
                {
                    PlayerWeaponsList[i].SetActive(false);
                }
            }

            if(player1)
            {
                
                if(Selected == 1 && (myScore.numbPlayer01Score > 50) )
                {
                    
                    myScore.SubtractPointsPlayer01(50);
                }
                else if(Selected == 2 && (myScore.numbPlayer01Score > 100) )
                {
                    
                    myScore.SubtractPointsPlayer01(50);
                }
                else if(Selected == 3 && (myScore.numbPlayer01Score > 200) )
                {
                    
                    myScore.SubtractPointsPlayer01(50);
                }
                else if(Selected == 4 && (myScore.numbPlayer01Score > 400 ))
                {
                    
                    myScore.SubtractPointsPlayer01(150);
                }
                else if(Selected == 5 && (myScore.numbPlayer01Score > 800 ))
                {
                    
                    myScore.SubtractPointsPlayer01(200);
                }
                else 
                {
                    Selected=0;
                    for(int i=0; i < PlayerWeaponsList.Length; i++)
                    {
                        //Debug.Log(i);
                        if(i ==Selected)
                        {
                            PlayerWeaponsList[i].SetActive(true);
                        }
                        else
                        {
                            PlayerWeaponsList[i].SetActive(false);
                        }
                    }
                }
            
            /*
                if(Selected == 3 && myScore.numbPlayer01Score > 200 )
                {
                    
                    myScore.SubtractPointsPlayer01(50);
                }
                else 
                {
                    Selected=0;
                }

                if(Selected == 4 && myScore.numbPlayer01Score > 400 )
                {
                    
                    myScore.SubtractPointsPlayer01(150);
                }
                else 
                {
                    Selected=0;
                }

                if(Selected == 5 && myScore.numbPlayer01Score > 800 )
                {
                    
                    myScore.SubtractPointsPlayer01(200);
                }
                else 
                {
                    Selected=0;
                }

                */
           
            }

           
        }
    }

    public void SpawnBulletAndDecreaseScore()
    {
         //if(Input.GetKeyDown(KeyCode.Space))
        if(Input.GetKeyDown(p1BulletFired)   && player1)
        {
            Instantiate(BulletList[Selected], barrelEndlist[Selected].position, PlayerWeaponsList[Selected].transform.rotation);
            if(player1)
            {

                myScore.SubtractPointsPlayer01((BulletList[Selected].GetComponent<PlayerShotSpace>().bulletSheildBreakerValue + 1 )*5) ;
               // Debug.Log("subtract 1 point");
            }
        }
        else if(Input.GetKeyDown(p2BulletFired)   && player2)
        {
            Instantiate(BulletList[Selected], barrelEndlist[Selected].position, PlayerWeaponsList[Selected].transform.rotation);
            if(player1)
            {

                myScore.SubtractPointsPlayer01((BulletList[Selected].GetComponent<PlayerShotSpace>().bulletSheildBreakerValue + 1 )*5) ;
               // Debug.Log("subtract 1 point");
            }
        }
    }
}
