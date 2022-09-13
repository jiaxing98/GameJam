using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fire : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        TractorStopPoint.OnTractorStops += FireStartFadingOut;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FireStartFadingOut()
    {
        _spriteRenderer.DOFade(0.0f, 5.0f);
    }
}
