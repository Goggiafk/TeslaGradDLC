using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preview : MonoBehaviour
{
    public GameObject prefab;

    private MeshRenderer myRend;
    public Material goodMat;
    public Material badMat;

    private BuildSystem buildSystem;
    private BuildManager buildManager;

    private bool isSnapped = false;
    public bool isFoundation = false;

    bool shift = false;
    public List<string> tagsISnapTo = new List<string>();
    // Start is called before the first frame update
    private void Start()
    {
        buildSystem = GameObject.FindObjectOfType<BuildSystem>();
        myRend = GetComponent<MeshRenderer>();
        ChangeColor();
     }

    void Update()
    {
        transform.LookAt(new Vector3(0, 0, 0));
        if (Input.GetKeyDown(KeyCode.LeftShift))
            shift = true;
        else if(Input.GetKeyUp(KeyCode.LeftShift))
            shift = false;
    }

    // Update is called once per frame
    public void Place()
    {
        Time.timeScale = BuildManager.tmscale;
        Instantiate(prefab, transform.position, transform.rotation);
        Destroy(gameObject);
        Debug.Log(shift);
        if (shift)
        {
            buildManager.tentbuild(buildManager.savedGameObject);
        }
    }

    public void ChangeColor()
    {
        if(isSnapped)
        {
            myRend.material = goodMat;
        }
        else
        {
            myRend.material = badMat;
        }

        if(isFoundation)
        {
            myRend.material = goodMat;
            isSnapped = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Invalid");
        buildSystem.PauseBuild(true);
        Debug.Log(other.name);
        for (int i = 0; i < tagsISnapTo.Count; i++)
        {
            string currentTag = tagsISnapTo[i];

            if(other.tag == currentTag)
            {
                buildSystem.PauseBuild(true);
                transform.position = other.transform.position;
                isSnapped = true;
                ChangeColor();
            }
            /*if (other.tag == "Mine")
            {
                buildSystem.PauseBuild(true);
            }*/
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < tagsISnapTo.Count; i++)
        {
            string currentTag = tagsISnapTo[i];

            if (other.tag == currentTag)
            {
               isSnapped = false;
                ChangeColor();
            }
        }
    }

    public bool GetSnapped()
    {
        return isSnapped;
    }
}
