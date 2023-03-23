using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static ILogger logger = Debug.unityLogger;

    private CharacterController controller;
    private Transform transform;

    // Move elements
    private bool isMoving;
    Vector3 moveTarget;
    private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        this.controller = this.GetComponent<CharacterController>();       
        this.transform = this.GetComponent<Transform>();
        this.moveTarget = this.transform.position;
        this.isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {        
        if(this.isMoving) this.move();
    }

    /// Will move the player to the indicated Vector3 location
    public void MoveTo(Vector3 moveVect){
        this.moveTarget = moveVect;
        this.isMoving = true;
    }

    // Move the player to moveTarget location
    private void move(){
        this.transform.LookAt(new Vector3(this.moveTarget.x, this.transform.position.y, this.moveTarget.z));
        Vector3 forward = this.transform.TransformDirection(Vector3.forward);
        this.controller.SimpleMove(forward * this.speed);
        
        float distance = Vector3.Distance(this.transform.position, this.moveTarget) - this.transform.position.y;
        if(distance < 0.1){
            this.stopMove();
        }
    }

    private void stopMove(){
        this.isMoving = false;
        this.moveTarget = this.transform.position;
    }
}
