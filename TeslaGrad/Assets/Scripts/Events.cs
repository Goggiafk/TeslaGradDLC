using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Events : MonoBehaviour
{
    public GameObject screamer;
    public Text timetext;
    float day = 0;
    float timescale;
    public GameObject info;
    public GameObject interlol;
    public GameObject bild;
    public Animator buildmen;
    public GameObject escmen;
    // Start is called before the first frame update
    void Start()
    {
        timescale = Time.timeScale;
        StartCoroutine(Timer(1f, () => { Time.timeScale = 0; }));
        StartCoroutine(Timer(1f, () => { interlol.SetActive(false); }));
        StartCoroutine(Timer(1f, () => { info.SetActive(true); }));
    }

    public void bildpannel(GameObject but)
    {
        but.SetActive(!but.activeInHierarchy);
        bild.SetActive(!bild.activeInHierarchy);
    }
    public void close(GameObject button)
    {
        button.SetActive(false);
        interlol.SetActive(true);
        Time.timeScale = timescale;
        buildmen.Play("Up");
    }

    public void end()
    {
        Time.timeScale = timescale;
        escmen.SetActive(false);
        interlol.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            screamer.SetActive(!screamer.activeInHierarchy);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            interlol.SetActive(false);
            escmen.SetActive(true);
            Time.timeScale = 0;
        }
        if (Input.GetKey(KeyCode.Alpha1))
        Time.timeScale = 0.333f;
        if (Input.GetKey(KeyCode.Alpha2))
        Time.timeScale = 0.75f;
        if (Input.GetKey(KeyCode.Alpha3))
        Time.timeScale = 1f;

        day += Time.timeScale;
        timetext.text = day.ToString();
    }
    IEnumerator Timer(float time, System.Action action)
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        action();
    }
}
