using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    private Dictionary<Vector3, Vector3> offset = new Dictionary<Vector3, Vector3>(){
        {new Vector3(0f, 20f, -11f), new Vector3(60f, 90f, 0f)}
    };
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        print(offset[new Vector3(0f, 20f, -11f)]);
        transform.position = target.position;
        // transform.rotation = offset.ElementAt(index).Value;
    }
}
