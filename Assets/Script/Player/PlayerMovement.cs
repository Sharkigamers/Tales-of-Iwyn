/*
 * Created Date: 21-10-22
 * Author: Gabriel Danjon
 * -----
 * Last Modified: 21-10-22 2:56:28 pm
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

    float speed = 0.1f;

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
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        _characterController.Move(new Vector3(xMovement, 0f, zMovement).normalized);
    }
}
