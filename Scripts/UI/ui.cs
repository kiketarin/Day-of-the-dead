using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui : MonoBehaviour
{
    public Image Vida1;
    public Image Vida2;
    public Image Vida3;
    public PlayerStats player;
    // Start is called before the first frame update
    void Start()
    {
              Vida1.enabled = true;
            Vida2.enabled = true;
            Vida3.enabled = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if(player.Lifes_==3){
            Vida1.enabled = true;
            Vida2.enabled = true;
            Vida3.enabled = true;
        }else if(player.Lifes_==2){
            Vida1.enabled = true;
            Vida2.enabled = true;
            Vida3.enabled = false;
        }else if(player.Lifes_==1){
            Vida1.enabled = true;
            Vida2.enabled = false;
            Vida3.enabled = false;
        }else if(player.Lifes_==0){
            Vida1.enabled = false;
            Vida2.enabled = false;
            Vida3.enabled = false;
        }
    }
}
