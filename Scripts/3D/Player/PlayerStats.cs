using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]private float Health_;
    [SerializeField]private float Stamina_;
    private float StaminaTime_=0;
    [SerializeField]private float StaminaTimeMax_= 5;
    public int Lifes_=3;
    public Image barraDeVida;
    public Image barraDestamina;

    private void Start()
    {
        Health_ = 30;
    }

    public float ReturnHeal()
    {
        return Health_;
    }

    public void Damage(float damage)
    {
        Health_=Health_- damage;
        if (Health_ <= 0)
        {
            Lifes_--;
            Health_ = 30;
        }
    }
    public float ReturnStamina()
    {
        return Stamina_;
    }
    

    public void RegenStamina()
    {
        if (StaminaTime_ < StaminaTimeMax_)
        {
            StaminaTime_ += 1 * Time.deltaTime;
        }
        else
        {
            StaminaTime_ = 0;
            Stamina_ += 10;
            if (Stamina_ > 100)
            {
                Stamina_ = 100;
            }
           
        }
    }

    public void UseStamina(float use)
    {
        Stamina_ -= use;
    }
    
    // Update is called once per frame
    void Update()
    {
        barraDeVida.fillAmount = Health_/30.0f;
        barraDestamina.fillAmount = Stamina_ / 100.0f;
        Mathf.Clamp(Health_, 0, 100);
        if (Lifes_ <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
