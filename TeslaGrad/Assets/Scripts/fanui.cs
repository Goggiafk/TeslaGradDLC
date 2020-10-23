using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanui : MonoBehaviour
{
    public GameObject ui;

    public GameObject back;

    public void about()
    {
        ui.SetActive(false);
        back.SetActive(true);
    }
    public void backing()
    {
        back.SetActive(false);
        ui.SetActive(true);
    }
}
