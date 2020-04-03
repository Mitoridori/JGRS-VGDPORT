using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleColor : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer[] meshRenderers;

    [SerializeField]
    private Material taken;

    [SerializeField]
    private Material available;

    private void Update()
    {
        gameObject.transform.Rotate(0, 360, 0);
    }

    public void SetIconMaterialTaken()
    {
        foreach (MeshRenderer renderer in meshRenderers)
        {
            renderer.material = taken;
        }
    }

    public void SetIconMaterialAvailable()
    {
        foreach (MeshRenderer renderer in meshRenderers)
        {
            renderer.material = available;
        }
    }
    
}
