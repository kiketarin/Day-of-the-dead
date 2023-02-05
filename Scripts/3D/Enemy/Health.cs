using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
// Start is called before the first frame update
    [SerializeField]
    private float Vida_ =1;

    public void quitarVida(int value){
        if(Vida_>0){
            Vida_-=value;
        }
    }
    public void sumarvida(int value){
        if(Vida_<15){
            Vida_+=value;
        }
    }
    public float returnvida(){
        return Vida_;
    }
    // Update is called once per frame
   
}
