using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int HealEnemy_;
    private GameObject Goal_;
    private NavMeshAgent Agent_;
    private Animator animacion_;
    private PlayerAttack PlayerStats_;
    private EnemySpawner Contador;
    void Start()
    {
        Agent_ = GetComponent<NavMeshAgent>();
        Goal_= GameObject.Find("Player");
        animacion_ = GetComponent<Animator>();
        PlayerStats_ = GameObject.Find("Player").GetComponent<PlayerAttack>();
        Contador = GameObject.Find("GameManager").GetComponent<EnemySpawner>();


    }

    
    private void  OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            HealEnemy_--;
            other.gameObject.GetComponent<Collider>().enabled = false;
            if (HealEnemy_ <= 0)
            {
                Contador.EnemyDead++;
                Agent_.speed = 0.0f;
                Agent_.SetDestination(Goal_.transform.position);
                Agent_.enabled = false;
            }
        }
        
    }

    private void DeadEnemy(){
        Destroy(gameObject);
    }
    

    void Update () {
        
        if (Agent_.enabled)
        {
            if (Vector3.Distance(transform.position, Goal_.transform.position) < 4.0f)
            {
                Agent_.SetDestination(transform.position);
                animacion_.SetBool("Attack", true);
                animacion_.SetBool("Walk", false);
            }
            else{
                Agent_.SetDestination(Goal_.transform.position);
                animacion_.SetBool("Walk", true);
                animacion_.SetBool("Attack", false);
            }
           
        }
        if (HealEnemy_ <= 0)
        {

 
            animacion_.SetBool("Dead",true);
            Invoke("DeadEnemy",6.5f);
        }
    }
   

    
}
