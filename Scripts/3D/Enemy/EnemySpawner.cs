using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float Time_;
    private int EnemyCounter_;
    private float Timer_;
    public GameObject[] EnemyInstance_;
    public Transform PlayerPosition_;
    public Transform[] Teleport;
    private Transform TeleportSelected_;
    public int EnemyDead;
    void Start()
    {
        Timer_ = Time_;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyCounter_ < 10)
        {
            if (Timer_ <= 0)
            {
                int i = Random.Range(0,4);
                int j = Random.Range(0,2);
                EnemySpawn(Teleport[i],EnemyInstance_[j]);
                Timer_ = Time_ ;
                EnemyCounter_++;
            }
            else
            {
                Timer_ = Timer_ - (1 * Time.deltaTime);
            }    
        }

        if (EnemyDead > EnemyCounter_)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

        }
    }

    void EnemySpawn(Transform TpPos, GameObject EnemyInstance)
    {
        
        GameObject EnemyInstanceGo = Instantiate<GameObject>(EnemyInstance, TpPos.position, 
            PlayerPosition_.rotation );
    }
}
