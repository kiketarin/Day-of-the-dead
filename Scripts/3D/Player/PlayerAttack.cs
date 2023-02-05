using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerStats Stats_;
    public Collider weapon_;
    private bool Shield_;
    Animator animacion_;
    public GameObject escudo_;
    public AudioSource Altavoces;
    public AudioClip Sonido;
    private bool vivo_;
    void Start()
    {
        animacion_ = GetComponent<Animator>();
        weapon_.enabled = false;
        escudo_.SetActive(false);
        Shield_ = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && (Stats_.ReturnStamina()>15))
        {
            
            attack();
            Stats_.UseStamina(15.0f);
        }
        else if(Input.GetMouseButton(1) && (Stats_.ReturnStamina()>7.5f))
        {
            Stats_.UseStamina(7.5f* Time.deltaTime);
            Deffend();
        }
        else
        {
            animacion_.SetBool("defence",false);
            Shield_ = false;
            Stats_.RegenStamina();
            escudo_.SetActive(false);
        }
    }

    private void attack()
    {
        animacion_.SetBool("attack", true);
        Altavoces.PlayOneShot(Sonido);
        weapon_.enabled = true;
        Invoke("DisableAttack",1.5f);
    }
    private void Deffend()
    {
        animacion_.SetBool("defence",true);
        Shield_ = true;
        escudo_.SetActive(true);
    }
    private void DisableAttack()
    {
        animacion_.SetBool("attack", false);
        weapon_.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !Shield_ )
        {
            Stats_.Damage(5.0f);
        }
        if (collision.gameObject.CompareTag("Enemy 2") && !Shield_ )
        {
            Stats_.Damage(10.0f);
        }
    }
    /*public void DoDamage()
    {
        if (!Shield_)
        {
            Stats_.Damage();
        }
    }*/
}
