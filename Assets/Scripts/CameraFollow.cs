using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject targetObject;
    float cameraWidth;

    // Use this for initialization
    void Start () {
        float height = 2.0f * Camera.main.orthographicSize;
        cameraWidth = height * Camera.main.aspect;
    }
	
	// Update is called once per frame
	void Update () {
        float targetObjectX = targetObject.transform.position.x;
        
        Vector3 newCameraPosition = transform.position;
        newCameraPosition.x = targetObjectX + 15;
        transform.position = newCameraPosition;
    }
}
