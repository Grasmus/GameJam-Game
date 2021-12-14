using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float axisX = 0f, axisY = 0f;
    private Rigidbody2D player;
    public float moving_speed = 5f;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        axisX = Input.GetAxisRaw("Horizontal");
        axisY = Input.GetAxisRaw("Vertical");

        player.velocity = new Vector2(axisX * moving_speed, axisY * moving_speed);
    }
}
