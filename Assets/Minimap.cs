using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
	private static Minimap instance;

    public Transform player;
    public Transform MainCamera;

	private Camera minimapCamera;
    
	private void Awake() {
		instance = this;
		minimapCamera = transform.GetComponent<Camera>();
	}

    void LateUpdate() 
	{
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
		transform.position = newPosition;

		transform.rotation = Quaternion.Euler(90f, MainCamera.eulerAngles.y, 0f);
    }

void Update()
    {
        if (Input.GetButtonDown("Zoom Out Minimap") && instance.minimapCamera.orthographicSize < 100)
        {
			Debug.Log("Using ");
			instance.minimapCamera.orthographicSize += 10;
        }
        if (Input.GetButtonDown("Zoom In Minimap") && instance.minimapCamera.orthographicSize > 20)
        {
			Debug.Log("Using");
			instance.minimapCamera.orthographicSize -= 10;
        }
    }
}
