using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D  (Collider2D colider)
    {
        if(colider.tag == "Player")
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}
