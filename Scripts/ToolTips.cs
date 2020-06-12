using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTips : MonoBehaviour
{

    [Header("Dispay the information")]
    public string objectName;
    [TextArea]
    public string objectInfo;

    [Header("Dispay the information")]
    public GameObject toolTipWindow;
    public Text displayName;
    public Text displayInfo;

    void OnMouseEnter()
    {
        toolTipWindow.SetActive(true);

        if (toolTipWindow != null)
        {
            displayName.text = objectName;
            displayInfo.text = objectInfo;
            
        }
    }

    void OnMouseExit()
    {
        toolTipWindow.SetActive(false);
    }

}


