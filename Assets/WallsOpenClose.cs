using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsOpenClose : MonoBehaviour
{

    //public GameObject[] Walls;
    // Start is called before the first frame update
    GameObject[] Walls;
    void Start()
    {
        Walls = GameObject.FindGameObjectsWithTag("Wall");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.G))
        {
           
            for (int i = 0; i < Walls.Length; i++)
            {
                Walls[i].SetActive(true);
            }
        }
    }
}
