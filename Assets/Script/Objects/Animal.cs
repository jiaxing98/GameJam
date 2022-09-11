using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceToRun;

    private Transform _transform;
    private float _distanceToStop;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _distanceToStop = transform.localPosition.x - _distanceToRun;

        AnimalRunPoint.OnAnimalStartRunning += AnimalStartRunning;
    }

    public void AnimalStartRunning()
    {
        StartCoroutine(StartRunning());
    }

    IEnumerator StartRunning()
    {
        while (_transform.localPosition.x > _distanceToStop)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
            yield return null;
        }
    }
}
