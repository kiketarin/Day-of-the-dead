using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class PlayerMovement : MonoBehaviour
{

    private Transform tr_;
    private Rigidbody rb_;
    private Vector3 inputValues_;
    [SerializeField]
    private Camera camera_;
    private Vector3 PlayerDirection_;
    /*--------------*/
    public float velocityChange_;
    public Transform Player_camera;
    public float vel_down_mul_;
    Animator animacion_;

    private Vector3 mouse;
    private Vector2 MidWindow;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = Player_camera.position;
        tr_ = GetComponent<Transform>();
        rb_ = GetComponent<Rigidbody>();
        animacion_ = GetComponent<Animator>();
        
        MidWindow.x = Screen.width/2.0f;
        MidWindow.y = Screen.height/2.0f;

        if (rb_ == null)
        {
            rb_ = gameObject.AddComponent<Rigidbody>();
        }

        inputValues_ = new Vector3();
        
    }
     
    void updateMovement(){
        inputValues_ = new Vector3(Input.GetAxis("Vertical"), 0.0f, Input.GetAxis("Horizontal"));

        mouse = Input.mousePosition;
    }
        // Update is called once per frame
    void Update()
    {
        CameraMovement();
        updateMovement();
    }

    void movement()
    {
        

        if (inputValues_.x !=0 || inputValues_.z !=0)
        {
            animacion_.SetBool("walk", true);
            PlayerDirection_ = (tr_.forward * inputValues_.x ).normalized;
        }
        else
        {
            animacion_.SetBool("walk", false);
            PlayerDirection_ *= vel_down_mul_;

        }

        Vector3 rotation = new Vector3( mouse.x - MidWindow.x, 0.0f, mouse.y - MidWindow.y);
        tr_.rotation = UnityEngine.Quaternion.LookRotation( rotation);
        
        rb_.velocity =  PlayerDirection_ * velocityChange_;
      

    }

    void CameraMovement()
    {
        Player_camera.position = tr_.position + offset;

    }
    void FixedUpdate(){
       if(!animacion_.GetBool("attack")){
        movement();

       }
        
    }
}