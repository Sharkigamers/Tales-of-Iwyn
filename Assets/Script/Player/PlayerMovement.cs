/*
 * Created Date: 21-10-22
 * Author: Gabriel Danjon
 * -----
 * Last Modified: 21-10-22 3:28:21 pm
 * Modified By: Gabriel Danjon
 * -----
 * Copyright (c) 2021 Da2ny's world
 * 
 * A clean code for a better programming
 * -----
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController _characterController;

    float moveSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate() {
        Movement();
    }

    void Movement() {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;

        if (direction.magnitude >= 0.1)
            _characterController.Move(direction * moveSpeed);
        if (direction != Vector3.zero)
            gameObject.transform.forward = direction;
    }
}
