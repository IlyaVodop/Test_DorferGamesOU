using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    [SerializeField] private GameObject _bodyPrefab;
    [SerializeField] private int _maxBody = 10;
    [SerializeField] private int _startBody = 3;
    [SerializeField] private float _decreaseScale = 1.05f;

    [SerializeField] private float _eatingSpeed = 0.1f;
    [SerializeField] private float _eatingBodyPartSizeScale = 1.7f;

    private List<GameObject> _body;
    private List<Vector3> _bodyPartsOriginalScale;


    private void Start()
    {
        _body = new List<GameObject>();
        _bodyPartsOriginalScale = new List<Vector3>();
        for (int i = 0; i < _startBody; i++)
        {
            IncreaseBodyLength();
        }
    }
    public void IncreaseBodyLength()
    {
        if (_body.Count == _maxBody)
            return;

        Vector3 position;
        if (_body.Count == 0)
        {
            position = transform.position + Vector3.back;
        }

        else
        {
            position = _body[_body.Count - 1].transform.position + Vector3.back;
        }


        var bodyPart = Instantiate(_bodyPrefab, position, Quaternion.identity);

        var smoothFollow = bodyPart.AddComponent<SmoothFollow>();
        if (_body.Count == 0)
        {
            smoothFollow.SetTarget(transform);
        }
        else
        {
            smoothFollow.SetTarget(_body[_body.Count - 1].transform);
        }

        if (_body.Count != 0)
            bodyPart.transform.localScale = _body[_body.Count - 1].transform.localScale / _decreaseScale;
        _body.Add(bodyPart);
        _bodyPartsOriginalScale.Add(bodyPart.transform.localScale);
    }
    public IEnumerator Ingestion()
    {
        for (int i = 0; i < _body.Count; i++)
        {
            var bodyPart = _body[i];
            bodyPart.transform.localScale = _bodyPartsOriginalScale[i];
            bodyPart.transform.localScale *= _eatingBodyPartSizeScale;
            yield return new WaitForSeconds(_eatingSpeed);
            bodyPart.transform.localScale = _bodyPartsOriginalScale[i];
        }
        IncreaseBodyLength();
    }
}
