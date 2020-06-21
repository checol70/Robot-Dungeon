using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour{
    //Declare variables for the speed, the fov, etc

    public float zSpeed;
    public float fovMin;
    public float fovMax;
    public float orthoMin;
    public float orthoMax;


    private Camera myCam;




    void Start()
    {
        myCam = GetComponent<Camera>();
    }

    void Update(){
        if (myCam.orthographic)
        {


            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                myCam.orthographicSize += zSpeed;
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                myCam.orthographicSize -= zSpeed;
            }

            myCam.orthographicSize = Mathf.Clamp(myCam.orthographicSize, orthoMin, orthoMax);
        }
        else{


        }

    }
}
