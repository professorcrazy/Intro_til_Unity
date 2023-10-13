using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerController2D : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction;
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        rb.velocity = direction.normalized * speed;
    }
}
