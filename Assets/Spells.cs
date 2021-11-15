using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spells : MonoBehaviour
{
    public ParticleSystem spark;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            spark.Play();
        }
    }
}

