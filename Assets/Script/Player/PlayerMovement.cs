/*
 * Created Date: 21-10-22
 * Author: Gabriel Danjon
 * -----
 * Last Modified: 21-10-22 6:20:00 pm
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
    public Animator _playerAnimator;

    public float StartAnimTime = 0.3f;
    public float StopAnimTime = 0.15f;

    float gravity = -12f;

    public float desiredRotationSpeed = 0.1f;
    float moveSpeed = 0.2f;

    Vector3 velocity;

    private Camera _mainCam;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Gravity();
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R)) {
            _playerAnimator.SetBool("Cast", true);
            _playerAnimator.Play("attack01");
        }
    }
    
    void Gravity() {
        velocity.y += gravity * Time.deltaTime;
        _characterController.Move(velocity * Time.deltaTime);
    }

    private void FixedUpdate() {
        Movement();
    }

    void Movement() {
        Vector3 forward = new Vector3(_mainCam.transform.forward.x, 0, _mainCam.transform.forward.z);
        Vector3 right = new Vector3(_mainCam.transform.right.x, 0, _mainCam.transform.right.z);

        float xMovement = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");

        var direction = (right * xMovement + forward * zMovement).normalized;
        float animationSpeed = new Vector2(xMovement, zMovement).sqrMagnitude;

        if (direction.magnitude >= 0.1) {
            _characterController.Move(direction * moveSpeed);
            _playerAnimator.SetFloat("Run", animationSpeed, StartAnimTime, Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), desiredRotationSpeed);
        }
        else {
            _playerAnimator.SetFloat("Run", animationSpeed, 0f, Time.deltaTime);
        }
        if (direction != Vector3.zero)
            gameObject.transform.forward = direction;

    }
}
