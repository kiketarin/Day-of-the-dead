using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMouse : MonoBehaviour
{

    private bool position_new_;
    private float speed_ = 0.1f;
    [SerializeField]
    private float rand_vertical;
    [SerializeField]
    private float rand_horizontal;
    [SerializeField]
    private bool check1 = false;
    [SerializeField]
    private bool check2 = false;
    private int count_;
    Light lt;
    // Start is called before the first frame update
    void Start()
    {
         lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {        
        if(position_new_){
            if(transform.position.x != rand_horizontal){
                if(rand_horizontal > transform.position.x){
                    transform.position = transform.position + new Vector3(speed_,0.0f,0.0f);

                }
                if(rand_horizontal < transform.position.x){
                    transform.position = transform.position - new Vector3(speed_,0.0f,0.0f);

                }

            }

            if(transform.position.y != rand_vertical){
                if(rand_vertical > transform.position.y){
                    transform.position = transform.position + new Vector3(0.0f,speed_,0.0f);

                }
                if(rand_vertical < transform.position.y){
                    transform.position = transform.position - new Vector3(0.0f,speed_,0.0f);

                }

            }

            if(transform.position.y < rand_vertical+0.1f && transform.position.y > rand_vertical-0.1f){
                check2=true;
            }

            if(transform.position.x < rand_horizontal+0.1f && transform.position.x > rand_horizontal-0.1f){
                check1=true;
            }

            if(check1&& check2){
                position_new_=false;
                check1=false;
                check2=false;
            }
        }else{
            rand_horizontal=Mathf.Round((Random.Range(-10.0f, 10.0f)*100))/100;
            rand_vertical=Mathf.Round((Random.Range(-10.0f, 10.0f)*100))/100;
            position_new_ = true;
        }
        
    }

    void FixedUpdate(){
        
        count_++;
        if(count_<20){
            lt.range =0;
        }else if(count_>=20 && count_<70){
            lt.range =50;
        }else{
            count_=0;
        }
    }
}
