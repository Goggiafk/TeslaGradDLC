using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public Camera cam;
    public LayerMask layer;
    private GameObject previewGameObject = null;
    private Preview previewScript = null;
    private GameObject rot = null;

    public float stickTolerance = 1.5f;

    public bool isBuilding = false;
    private bool pauseBuilding = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(rot.name);
            rot.transform.Rotate(0, 90f, 0);
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            Time.timeScale = BuildManager.tmscale;
            CancelBuild();
        }
        if(Input.GetMouseButtonDown(0) && isBuilding)
        {
            if(previewScript.GetSnapped())
            {
                StopBuild();
            }
            else
            {
                Debug.Log("Not snapped");
            }
        }

        if(isBuilding)
        {
            if(pauseBuilding)
            {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                if(Mathf.Abs(mouseX) >= stickTolerance || Math.Abs(mouseY) >= stickTolerance)
                {
                    pauseBuilding = false;
                }
            }
            else
            {
                DoBuildRay();
            }
        }
    }

    public void NewBuild(GameObject _go)
    {
        previewGameObject = Instantiate(_go, Vector3.zero, Quaternion.identity);
        previewScript = previewGameObject.GetComponent<Preview>();
        isBuilding = true;
        rot = GameObject.Find("rot");
    }

    public void CancelBuild()
    {
        Destroy(previewGameObject);
        previewGameObject = null;
        previewScript = null;
        isBuilding = false;
    }

    private void StopBuild()
    {
        previewScript.Place();
        previewGameObject = null;
        previewScript = null;
        isBuilding = false;
    }

    public void PauseBuild(bool _value)
    {
        pauseBuilding = _value;
    }

    private void DoBuildRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit, 100f, layer))
        {
            float y = hit.point.y + (previewGameObject.transform.localScale.y / 2f);
            Vector3 pos = new Vector3(hit.point.x, y, hit.point.z);
            previewGameObject.transform.position = pos;
            previewGameObject.transform.position = hit.point;
            Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);
            Debug.Log(hit.transform.tag);
            if (hit.transform.tag != "Ground")
                PauseBuild(false);
        }
    }





    /*public GameObject prefab;
    public GameObject but1;
    Vector3 moving;
    Vector3 mousePosition;
    public GameObject pref;
    Rigidbody rig;
    GameObject mass;
    // Start is called before the first frame update
    void Start()
    {

    }
        void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            pref = Instantiate(prefab);
            //pref = Resources.Load<GameObject>("objects/palatka2");
            //pref.transform.position = new Vector3(0, 0, 0);
            //pref = Instantiate(prefab);
            //pref = Resources.Load<GameObject>("objects/palatka2");

        }    
            pref.transform.position = moving;
        if (Input.GetKey(KeyCode.UpArrow))
            moving += transform.forward * 10 * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow))
            moving -= transform.forward * 10 * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
            moving -= transform.right* 10 * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
            moving += transform.right * 10 * Time.deltaTime;
        pref.transform.LookAt(new Vector3(0, 0, 0));
        Vector3 reserve;
        reserve = transform.localEulerAngles;
        Ray pos = new Ray(pref.transform.position, -pref.transform.up);
        RaycastHit his;
        if (Physics.Raycast(pos, out his, 100))
        {
                if (his.transform.tag == "Ground")
                {
                    pref.transform.position = his.point + new Vector3(0, 0, 0);
                }
                
        }
        transform.localEulerAngles = new Vector3(reserve.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
        Debug.DrawRay(pos.origin, pos.direction * 50, Color.red);
    }



        public void Place()
        {
        //pref = Instantiate(prefab, new Vector3(4, 0, 4), Quaternion.identity);
        pref = Instantiate(prefab);
        
    }*/
}