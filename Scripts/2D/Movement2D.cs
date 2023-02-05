using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement2D : MonoBehaviour
{

    [SerializeField]
    private float speed_ = 0.1f;
    private bool picture_ = false;

    [SerializeField]
    private int top_;
    [SerializeField]
    private int down_;
    [SerializeField]
    private int left_;
    [SerializeField]
    private int right_;
    


    //Movement of the player
    void MovementCamera(){
        if (Input.GetKey("up") && transform.position.y<top_)
        {
            transform.position = transform.position + new Vector3(0.0f,speed_,0.0f);
        }

        if (Input.GetKey("down") && transform.position.y>down_)
        {
            transform.position = transform.position + new Vector3(0.0f,-speed_,0.0f);
        }

        if (Input.GetKey("left") && transform.position.x>left_)
        {
            transform.position = transform.position + new Vector3(-speed_,0.0f,0.0f);
        }

        if (Input.GetKey("right") && transform.position.x<right_)
        {
            transform.position = transform.position + new Vector3(speed_,0.0f,0.0f);
        }
    }

    //Raycast to detecte the picture
    void CollisionCamera(){
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        if (Physics.Raycast(transform.position, forward, out hit)){
            if(hit.transform.CompareTag("Picture")){
                picture_ = true;
            }
        }
    }

    //Collision with picture
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Picture"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    //This function make the movement of the camera
    void EnterPicture(){
        transform.position = transform.position + new Vector3(0.0f,0.0f,speed_);
    }

    // Main 
    void FixedUpdate()
    {
    
        if(picture_){
            EnterPicture();
        }else{
            MovementCamera();
        }

    }

    void Update(){
        if(!picture_){
            if (Input.GetButtonDown("Fire1"))
            {
                CollisionCamera();
            }
        }

    }
}
