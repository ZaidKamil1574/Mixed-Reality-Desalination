using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;


namespace JI.Hololens.Tutorials.Effects
{

    public class GazeMaterialToggle : MonoBehaviour, IFocusable
    {
        [Tooltip("Material displayed when gazed upon")]
        public Material activeMaterial;

        [Tooltip("Material displayed when not gazed upon")]
        public Material inactiveMaterial;

        private Renderer[] Renderers { get; set; }
        // Use this for initialization
        void Start()
        {
            Renderers = GetComponentsInChildren<Renderer>();
            SetMaterial(inactiveMaterial);
        }



        public void OnFocusEnter()

        {
            SetMaterial(activeMaterial);

        }

        public void OnFocusExit()
        {
            SetMaterial(inactiveMaterial);
        }

        private void SetMaterial(Material material)
        {
            foreach (var renderer in Renderers)
            {
                renderer.material = material;
            }
        }
    }
}
