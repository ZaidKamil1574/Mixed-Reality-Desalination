
using UnityEngine;

namespace JI.Hololens.Tutorials.Effects
{
    public class GazeMaterialTransition : GazeTransitionBase
    {
        [Tooltip("Material displayed when gazed upon")]
        public Material activeMaterial;

        [Tooltip("Material displayed when not gazed upon")]
        public Material inactiveMaterial;

        private Renderer Renderer { get; set; }

        // Use this for initialization
        void Start()
        { 
            Renderer = GetComponentInChildren<Renderer>();
        }

        // Update is called once per frame
        void Update()
        {

            if (Renderer == null)
                return;

            Renderer.material.Lerp(inactiveMaterial, activeMaterial, transitionFactor);

        }
    }
}
