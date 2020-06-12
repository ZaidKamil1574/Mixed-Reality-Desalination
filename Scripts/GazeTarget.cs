using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeTarget : MonoBehaviour
{

    public Color normalColor;
    public Color gazedColor;

    Renderer objRenderer;
    //[HideInInspector] public bool isGazed;



    // Use this for initialization
    void Start()
    {
        objRenderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GazeOn()
    {
        objRenderer.material.color = gazedColor;
    }
    public void GazeOff()
    {
        objRenderer.material.color = normalColor;
    }
}
