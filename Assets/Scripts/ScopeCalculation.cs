using UnityEngine;

public class ScopeCalculation : MonoBehaviour
{
    [SerializeField] private Camera scopeCamera;
    [SerializeField] private float notchWidthPercent = 0.07943f * 1.5f;
    [SerializeField] private Renderer scopeQuad;
    private Material scopeMaterial;

    private void Start()
    {
        scopeMaterial = scopeQuad.material;
    }

    public void ActivateCamera(bool activate)
    {
        scopeCamera.enabled = activate;// gameObject.SetActive(activate);
        scopeMaterial.SetFloat("_CamOn", activate ? 1f : 0f);
    }
}
