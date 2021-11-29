using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public GameObject Target;
    public float Distance;

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Target.transform.position.z + Distance);
    }
}
