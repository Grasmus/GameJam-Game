using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CameraTrigger : MonoBehaviour
{
    public Vector3 cameraChangePos;
    public Vector3 playerChangePos;
    private Camera cum;
    private int Rand;
    private bool IsCreate = false;


    GameObject Enemy;
    void Start()
    {
        //Enemy = Resources.LoadAll("Prefabs/enemies", typeof(GameObject));
        //Enemy = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/enemies/ghost1.prefab", typeof(GameObject));
        Enemy = GameObject.Find("ghost1 (1)");
        cum = Camera.main.GetComponent<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position += playerChangePos;
            cum.transform.position += cameraChangePos;
            
            Rand = Random.Range(1, 4);
            Vector3 camPos = new Vector3(cum.transform.position.x, cum.transform.position.y, -1);
            if (!IsCreate)
            {

            for (int i = 0; i < Rand; i++)
            {
                Instantiate(Enemy, camPos, cum.transform.rotation);
                camPos = new Vector3(cum.transform.position.x + i, cum.transform.position.y, -1);
            }
                IsCreate = true;
            }




        }
    }
}
