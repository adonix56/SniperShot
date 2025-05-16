using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestScopeCalculation : MonoBehaviour
{
    [SerializeField] private Camera scopeCamera;
    [SerializeField] private InputAction testInput;
    [SerializeField] private float notchWidthPercent = 0.07943f * 1.5f;


    private void Start()
    {
        testInput.Enable();
        testInput.performed += ctx => OnTestInput(ctx);
    }

    private void OnTestInput(InputAction.CallbackContext ctx)
    {
        Ray ray = scopeCamera.ViewportPointToRay(new Vector3(0.5f - notchWidthPercent, 0.5f, 0));
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 10f);

        Ray ray2 = scopeCamera.ViewportPointToRay(new Vector3(0.5f - (2 * notchWidthPercent), 0.5f, 0));
        Debug.DrawRay(ray2.origin, ray2.direction * 100f, Color.green, 10f);

        Ray ray3 = scopeCamera.ViewportPointToRay(new Vector3(0.5f - (3 * notchWidthPercent), 0.5f, 0));
        Debug.DrawRay(ray3.origin, ray3.direction * 100f, Color.blue, 10f);

        Ray ray4 = scopeCamera.ViewportPointToRay(new Vector3(0.5f - (4 * notchWidthPercent), 0.5f, 0));
        Debug.DrawRay(ray4.origin, ray4.direction * 100f, Color.yellow, 10f);

        Ray ray5 = scopeCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f - notchWidthPercent, 0));
        Debug.DrawRay(ray5.origin, ray5.direction * 100f, Color.cyan, 10f);

        Ray ray6 = scopeCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f - (2 * notchWidthPercent), 0));
        Debug.DrawRay(ray6.origin, ray6.direction * 100f, Color.magenta, 10f);

        Ray ray7 = scopeCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f - (3 * notchWidthPercent), 0));
        Debug.DrawRay(ray7.origin, ray7.direction * 100f, Color.white, 10f);

        Ray ray8 = scopeCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f - (4 * notchWidthPercent), 0));
        Debug.DrawRay(ray8.origin, ray8.direction * 100f, Color.grey, 10f);

        Debug.Log($"Shooting Ray {ray.origin} {ray.direction}");
    }
}
