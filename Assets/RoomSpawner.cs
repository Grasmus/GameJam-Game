using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomSpawner : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Rooms"))
        {
            Destroy(gameObject);
        }
    }
}
