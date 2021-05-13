using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float vel;
    public FIFO sceneController;
    // Start is called before the first frame update
    void Start()
    {
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<FIFO>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneController.cameraLock == false && Input.GetKey(KeyCode.A) && transform.position.x>=0)
        {
            transform.Translate(-vel,0,0);
        }
        if (sceneController.cameraLock == false && Input.GetKey(KeyCode.D) && transform.position.x <= 60)
        {
            transform.Translate(+vel, 0, 0);
        }
    }
}
