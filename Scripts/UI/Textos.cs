using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Textos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Textos_;
    [SerializeField]private int n_textos;
    private int TextSelect_;
    void Start()
    {
        TextSelect_ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (TextSelect_ < n_textos)
            {
                
                TextSelect_++;
                Textos_[TextSelect_].SetActive(true);
                Textos_[TextSelect_-1].SetActive(false);
            }
            if(TextSelect_ == n_textos){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
        }
    }
}