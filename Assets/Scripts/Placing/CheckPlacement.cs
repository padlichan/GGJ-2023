using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlacement : MonoBehaviour
{
    public Material placeable;
    public Material unplaceable;

    public bool overLapped;

    public MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer.material = placeable;
    }
    private void OnTriggerEnter(Collider other)
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<MycorrhizaSeeds>())
        {;
            var materials = meshRenderer.materials;

            for(int i = 0; i < materials.Length; i++)
            {
                materials[i] = unplaceable;
            }

            meshRenderer.materials = materials;
            //meshRenderer.materials[0] = unplaceable;
            //meshRenderer.materials[1] = unplaceable; 
            overLapped = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<MycorrhizaSeeds>())
        {
            var materials = meshRenderer.materials;

            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = placeable;
            }

            meshRenderer.materials = materials;
            //meshRenderer.materials[0] = placeable;
            //meshRenderer.materials[1] = placeable;
            overLapped = false;
        }
    }
}
