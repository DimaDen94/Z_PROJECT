using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarExplosive : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> _meshRenderers;
    [SerializeField] private List<GameObject> _dynamits;
    public void ShowDinamits() {
        foreach(MeshRenderer mesh in _meshRenderers)
            mesh.enabled = true;
    }
   
    public void BlowUp() {
        HideDinamits();
        foreach (GameObject particle in _dynamits)
            particle.SetActive(true);
    }
    private void HideDinamits()
    {
        foreach (MeshRenderer mesh in _meshRenderers)
            mesh.enabled = false;
    }
}

