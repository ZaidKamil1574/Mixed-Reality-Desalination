using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

namespace JI.Hololens.Tutorials.Effects
{
    public abstract class GazeTransitionBase : TransitionBehaviorBase, IFocusable
    {
        public void OnFocusEnter()

        {
            TransitionIn();

        }

        public void OnFocusExit()
        {
            TransitionOut();
        }


    }
}




