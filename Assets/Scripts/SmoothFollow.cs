using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform _target;


    [SerializeField] private float distance = 1f;

    [SerializeField] private float damping = 10f;

    private void Update()
    {
        if (!_target)
        {
            return;
        }


        var wantedX = _target.position.x;
        var currentX = transform.position.x;
        currentX = Mathf.Lerp(currentX, wantedX, damping * Time.deltaTime);


        transform.position = _target.position;
        transform.position += Vector3.back * distance;
        transform.position = new Vector3(currentX, transform.position.y, transform.position.z);
    }


    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
