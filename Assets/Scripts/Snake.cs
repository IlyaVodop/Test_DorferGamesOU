using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Snake : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _turnSpeed = 1f;
    [SerializeField] private float _feverTime = 5f;
    [SerializeField] private float _speedValue = 100f;
    [SerializeField] private float _turningSector = 1f;

    [SerializeField] private Material _material;


    public float TurningSector => _turningSector;
    public bool FeverMode { get; private set; }



    void Update()
    {
        if (FeverMode)
        {
            transform.DOMoveX(0, 1);
        }
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
    public void Move(Vector3 direction, bool move)
    {
        if (!FeverMode)
        {
            if (move)
            {
                transform.Translate(direction);
            }
            else
            {
                transform.Translate(direction * Time.deltaTime * _turnSpeed);
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -_turningSector, _turningSector), transform.position.y, transform.position.z);
            }
        }

    }
    public IEnumerator EnableFeverMode()
    {
        FeverMode = true;
        _speed *= _speedValue;
        yield return new WaitForSeconds(_feverTime);
        FeverMode = false;
        _speed /= _speedValue;
       
    }


    public void SetColor(Color color)
    {
        _material.color = color;
    }
}
