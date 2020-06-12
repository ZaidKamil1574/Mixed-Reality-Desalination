using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JI.Hololens.Tutorials.Effects
{

    public class GazeSpinTransition : GazeTransitionBase
    {
        public float maximumSpinSpeed = 30f;


        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.up, maximumSpinSpeed * transitionFactor * Time.deltaTime);
        }
    }
}
