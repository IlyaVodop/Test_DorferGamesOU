using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed = 100f;
    void Update()
    {
        transform.Rotate(new Vector3(0,1,0) * _speed * Time.deltaTime);
    }
}
