using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipLocation : MonoBehaviour
{

    public float xPosition;
    public float yPosition;
    public float zPosition;

    void Update()
    {
        this.transform.position = new Vector3(xPosition, yPosition, zPosition);
    }

}