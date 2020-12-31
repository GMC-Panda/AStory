using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{   
    [SerializeField] float navMeshSpeedModifier = 2f;
    [SerializeField] Camera playerCamera;
  
    LayerMask groundLayer;
    NavMeshAgent playerNavMesh;  
    Animator playerAnim; 
    
    Mouse mouse;

   private void Awake() 
   {       
       playerNavMesh = GetComponent<NavMeshAgent>();     
       playerAnim = GetComponent<Animator>();             
       playerNavMesh.speed=playerNavMesh.speed*navMeshSpeedModifier;      
       mouse = Mouse.current;   
       groundLayer = 8;    
   }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        MoveOnMouseClick();
        UpdateAnimator();      
        
    }

    private void MoveOnMouseClick()
    {
        if (mouse.rightButton.isPressed)
        {
            playerNavMesh.destination = ReadMousePosition();
        }
    }

    public Vector3 ReadMousePosition()    
    { 
                              
            RaycastHit hit;        
            Ray ray = playerCamera.ScreenPointToRay(new Vector3 (mouse.position.x.ReadValue(), mouse.position.y.ReadValue(),0f));            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer==groundLayer)
                {
                 return hit.point; 
                }
                else return transform.position;    
            }
            return transform.position;             
    }
    
    public void UpdateAnimator()
    {        
        Vector3 localVelocity = transform.InverseTransformDirection(playerNavMesh.velocity);
        float forwardMovSpd  = localVelocity.z;
        Debug.Log(localVelocity);
        playerAnim.SetFloat("forwardSpeed", forwardMovSpd);

    }

}
