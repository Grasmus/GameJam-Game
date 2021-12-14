using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOpenClose : MonoBehaviour
{

    public GameObject[] Doors;

    private GameObject[] Enemys;
    // Start is called before the first frame update
    void Start()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }
    bool isInRoom = false;
    bool isPressed = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isInRoom)
        {
            Debug.Log(Doors.Length);
            for (int i = 0; i < Doors.Length; i++)
            {

                Doors[i].SetActive(false);
                isPressed = true;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Here");
        if (other.CompareTag("Player"))
        {
            isInRoom = true;
        }
    }

}
