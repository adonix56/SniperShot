using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleLOD : MonoBehaviour
{
    [SerializeField] private float distanceThreshold = 6.5f;

    private List<Renderer> renderers;
    private XRClientPlayer vrPlayer;
    private bool prevDisplay = false;

    private void Start()
    {
        vrPlayer = XRClientPlayer.Instance;
        renderers = new List<Renderer>(GetComponentsInChildren<Renderer>());
    }

    private void Update()
    {
        if (vrPlayer != null)
        {
            float distanceSqr = Vector3.Distance(vrPlayer.transform.position, transform.position);
            //Debug.Log(distanceSqr);
            bool display = distanceSqr <= distanceThreshold * distanceThreshold;
            if (display != prevDisplay)
            {
                prevDisplay = display;
                SetRenderersEnabled(display);
            }
        }
    }

    private void SetRenderersEnabled(bool enabled)
    {
        foreach (var renderer in renderers)
        {
            if (renderer != null)
            {
                Debug.Log($"Display {enabled}");
                renderer.enabled = enabled;
            }
        }
    }
}
