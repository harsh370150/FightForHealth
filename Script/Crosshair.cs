using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Ray ray;
    public Camera camera;
    public GameObject aim;
    public LayerMask layer;
    public GameObject CrossHair;
    public Vector3 Distance;
    void LateUpdate()
    {
        ray = camera.ScreenPointToRay(CrossHair.transform.position);
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, layer))
        {
            aim.transform.position = hit.point;
        }
    }

}
