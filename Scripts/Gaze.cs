using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;


public class Gaze : MonoBehaviour {

    GameObject gazedObject;
    public float gazeMaxDistance;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Vector3 fwd = gameObject.transform.TransformDirection(Vector3.forward);
        Ray ray = new Ray(Camera.main.transform.position, fwd);
        RaycastHit hit;
        Debug.DrawRay(Camera.main.transform.position, fwd * gazeMaxDistance);

        if (Physics.Raycast(ray, out hit, gazeMaxDistance) && hit.collider != null)
        {
            if (hit.transform.tag == "gazeTarget")
            {
                if (hit.transform.gameObject != gazedObject)
                {
                    gazedObject = hit.transform.gameObject;

                    hit.transform.gameObject.GetComponent<GazeTarget>().GazeOn();
                }
            }

            else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                Debug.Log("Ray hit UI: " + hit.transform.name);
                gazedObject = hit.transform.gameObject;
                EventSystem.current.SetSelectedGameObject(gazedObject);


            }
            else
            {
                resetAllGazes();

            }

        }
        else
        {
            resetAllGazes();
        }
    }

    public void resetAllGazes()
    {
        if (gazedObject != null)
        {
            if (gazedObject.tag == "gazeTarget")
            {
                gazedObject.GetComponent<GazeTarget>().GazeOff();
            }
            else if (gazedObject.layer == LayerMask.NameToLayer("UI"))
            {
                EventSystem.current.SetSelectedGameObject(null);

            }
            gazedObject = null;
        }
    }
}
                