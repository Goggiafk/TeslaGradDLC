using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laws : MonoBehaviour
{
    public GameObject lawpanel;
    public GameObject openlaw;
    float tm;
    // Start is called before the first frame update
    void Start()
    {
        tm = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveto(Button button)
    {
        
    }

    public void openlawbook()
    {
        openlaw.SetActive(!openlaw.activeInHierarchy);
        lawpanel.SetActive(!lawpanel.activeInHierarchy);
        if (Time.timeScale == 0)
            Time.timeScale = tm;
        else
            Time.timeScale = 0;
    }
}
