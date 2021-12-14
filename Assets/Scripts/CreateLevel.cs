using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevel : MonoBehaviour
{
    public GameObject prefab;
    public int levelCountSection;
    public int heath;
    public int wigth;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < levelCountSection; i++)
        {
            Instantiate(prefab, new Vector3(i * heath, i * wigth), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
