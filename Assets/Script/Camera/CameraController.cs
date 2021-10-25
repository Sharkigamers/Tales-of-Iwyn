using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraController : MonoBehaviour
{
    public Transform target;

    private Dictionary<Vector3, Vector3> offset = new Dictionary<Vector3, Vector3>(){
        {new Vector3(0f, 20f, -11f), new Vector3(60f, 0f, 0f)},
        {new Vector3(-11f, 20f, 0), new Vector3(60f, 90f, 0f)},
        {new Vector3(0f, 20f, 11f), new Vector3(60f, 180f, 0f)},
        {new Vector3(11f, 20f, 0f), new Vector3(60f, -90f, 0f)},
    };
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right"))
            index -= 1;
        else if (Input.GetKeyDown("left"))
            index += 1;
        if (index > offset.Count - 1)
            index = 0;
        else if (index < 0)
            index = offset.Count - 1;
        transform.position = target.position + offset.ElementAt(index).Key;
        transform.rotation = Quaternion.Euler(offset.ElementAt(index).Value);
    }
}
