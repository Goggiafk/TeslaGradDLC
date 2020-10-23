using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LookAtCam : MonoBehaviour
{
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = cam.transform.eulerAngles;
    }
}
