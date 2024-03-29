﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public bool enableControl = true;

    public float force = 1.0f;

    public float maxSpeed = 5.0f;

    private Animator animator;
    private Rigidbody rb;

    
    private float pressedHorizontal = 0.0f;
    private float pressedVertical = 0.0f;

    void Start () {
        rb = GetComponent<Rigidbody>();
        
    }
    
	void Update () {
        if (!enableControl) return;

        pressedHorizontal = Input.GetAxisRaw("Horizontal");
        pressedVertical = Input.GetAxisRaw("Vertical");
        
        //水平方向の速度制限
        if(rb.velocity.x * rb.velocity.x + rb.velocity.z * rb.velocity.z > maxSpeed * maxSpeed)
        {
            Vector3 tmp = Vector3.ClampMagnitude(new Vector3(rb.velocity.x, 0, rb.velocity.z), maxSpeed);
            rb.velocity = tmp + Vector3.up * rb.velocity.y;

        }
        

    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(pressedHorizontal * force, 0, pressedVertical * force), ForceMode.Force);
        
    }
    
}
