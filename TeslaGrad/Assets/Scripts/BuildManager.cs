using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject but;
    public GameObject bild;
    public GameObject tent;
    public GameObject mine;
    public GameObject hothouse;
    public GameObject cube;
    public static float tmscale;
    public BuildSystem buildSystem;
    public GameObject savedGameObject;
    public void tentbuild(GameObject gog)
    {
        savedGameObject = gog;
        tmscale = Time.timeScale;
        Time.timeScale = 0;
        buildSystem.NewBuild(gog);
    }

    void close()
    {
        but.SetActive(!but.activeInHierarchy);
        bild.SetActive(!bild.activeInHierarchy);
    }
}
