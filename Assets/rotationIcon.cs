using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationIcon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public float lockPos;

    void Update()
    {
        // Locks the rotation.
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, transform.rotation.eulerAngles.x);
    }
}
