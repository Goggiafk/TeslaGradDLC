using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInf : MonoBehaviour
{
    public Camera cam1;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam1.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject);
                if (hit.transform.tag == "tent")
                {
                    Debug.Log("tent");
                }
            }
        }
    }
}
