using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flood : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _levelToRise;

    private Transform _transform;
    private float _levelStopRising;

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _levelStopRising = transform.localPosition.y + _levelToRise;

        //fire fade out completely
        TractorStopPoint.OnTractorStops += WaterStartRising;
    }

    public void WaterStartRising()
    {
        StartCoroutine(StartRising());
    }

    IEnumerator StartRising()
    {
        while (_transform.localPosition.y < _levelStopRising)
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
            yield return null;
        }
    }
}
