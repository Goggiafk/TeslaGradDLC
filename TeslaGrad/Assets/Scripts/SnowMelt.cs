using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMelt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Snow")
        {
            other.gameObject.SetActive(false);
            Debug.Log(other.gameObject);
        }
        Debug.Log(other);
    }
}
