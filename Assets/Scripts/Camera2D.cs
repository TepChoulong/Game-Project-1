using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{
    public Transform Target;

    public float smoothspeed = 0.125f;

    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 DesiredPosition = Target.position + offset;
        Vector3 SmoothCamera = Vector3.Lerp(transform.position, DesiredPosition, smoothspeed * Time.deltaTime);
        transform.position = SmoothCamera;
    }
}
