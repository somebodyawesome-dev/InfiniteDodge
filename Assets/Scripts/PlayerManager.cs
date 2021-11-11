using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerController3d controller;

   
    bool dissolving;
    bool gameOver = false;
    [SerializeField] Joystick joystick;

   public bool isDissolving()
    {
        return dissolving;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.collider.tag == "Obstacle" )
        {
            FindObjectOfType<GameLost>().stopGame();
            
        }
    }
    
    private void Start()
    {
        controller = GetComponent<PlayerController3d>();
        dissolving = false;
        
    }
    bool requestJump = false;

    private void Update()
    {
        int direction;
        if(joystick.Horizontal >= 0.3f)
        {
            direction = 1;
        }
        else if(joystick.Horizontal <= -0.3f)
        {
            direction = -1;
        }
        else
        {
            direction = 0;
        }
        //Input.GetAxis("Horizontal")
        // Input.GetButton("Jump")

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.position.x > Screen.width / 2)
            {
                requestJump = true;
            }
        }
        controller.move(direction,requestJump, Input.GetButtonUp("Jump"));
        if (dissolving)
        {
            doDissolving();
        }

    }

    private void LateUpdate()
    {
        requestJump = false;
    }

    public void doDissolving()
    {
        if (GetComponent<MeshRenderer>().material.GetFloat("_Stat") < 1)
        {

            GetComponent<MeshRenderer>().material.SetFloat("_Stat", GetComponent<MeshRenderer>().material.GetFloat("_Stat") + 0.25f * Time.deltaTime);
        }
        else
        {
            dissolving = false;

        }
    }
    private void FixedUpdate()
    {
        if(transform.position.y < 0  && !gameOver)
        {
            FindObjectOfType<GameLost>().stopGame();
            gameOver = true;
        }
    }

    public void dissolve()
    {
       
        dissolving = true;
    }
}
