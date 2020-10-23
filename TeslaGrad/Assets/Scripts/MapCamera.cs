using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
    public GameObject but;
    public GameObject allmen;
    public GameObject cameraobj;
    public GameObject camera;
    public GameObject camera2;
    public float speed = 20;
    float speed1;
    public float scrollspeed = 15;
    float scrollspeed1;
    public float rotatespeed = 95;
    float rotatespeed1;
    public static int movlim = 10;
    Vector3 moving;
    Vector3 lol;
    bool camcheck = false;
    // Start is called before the first frame update
    void Start()
    {
        speed1 = speed;
        rotatespeed1 = rotatespeed;
        scrollspeed1 = scrollspeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1f)
        {
            scrollspeed = scrollspeed1;
            speed = speed1;
            rotatespeed = rotatespeed1;
        }
        if (Time.timeScale == 0.333f)
        {
            scrollspeed = scrollspeed1 * 3;
            speed = speed1 * 3;
            rotatespeed = rotatespeed1 * 3;
        }
        cameraobj.transform.position = moving;
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - movlim)
            moving += transform.forward * (speed + moving.y) * Time.deltaTime;
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= movlim)
            moving -= transform.right * (speed + moving.y) * Time.deltaTime;
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= movlim)
            moving -= transform.forward * (speed + moving.y) * Time.deltaTime;
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - movlim)
            moving += transform.right * (speed + moving.y) * Time.deltaTime;
        /*if (Input.GetKey(KeyCode.Q))
            cameraobj.transform.Rotate(new Vector3(0f, -rotatespeed + moving.y, 0f) * Time.deltaTime);
        if (Input.GetKey(KeyCode.E))
            cameraobj.transform.Rotate(new Vector3(0f, rotatespeed + moving.y, 0f) * Time.deltaTime);*/
        if (moving == transform.position)
        { }
        else
        { }



        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float x = moving.x;
        float z = moving.z;
        moving += (transform.up * (-scroll) * 100f * scrollspeed * Time.deltaTime);
        if (moving.x <= -325f)
            moving.x = -325f;
        if (moving.x >= -275f)
            moving.x = -275f;
        if (moving.z <= -25f)
            moving.z = -25f;
        if (moving.z >= 25f)
            moving.z = 25f;
        if (moving.y > 50f)
        {
            moving.y = 50f;
            moving.x = x;
            moving.z = z;
        }
        if (moving.y < 10f)
        {
            but.SetActive(true);
            allmen.SetActive(true);
            ChangeCam();
            moving.y = 10f;
            moving.x = x;
            moving.z = z;
        }
    }

    void ChangeCam()
    {
        camcheck = true;
        camera2.SetActive(true);
        cameraobj.SetActive(false);
    }
}
