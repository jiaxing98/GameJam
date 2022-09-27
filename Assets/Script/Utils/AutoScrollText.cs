using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoScrollText : MonoBehaviour
{
    public enum Movement
    {
        Left_to_right = 0,
        Right_to_left = 1,
        Top_to_bottom = 2,
        Bottom_to_top = 3,
    }

    [SerializeField] private float _speed;
    [SerializeField] private float _textPosBegin;
    [SerializeField] private float _boundaryTextEnd;
    [SerializeField] private TMP_Text _mainText;
    [SerializeField] private Movement movement;
    [SerializeField] private bool isLooping;

    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(AutoScroll(movement));
    }

    IEnumerator AutoScroll(Movement movement)
    {
        switch (movement)
        {
            case Movement.Left_to_right:
                while (rectTransform.localPosition.x < _boundaryTextEnd)
                {
                    rectTransform.Translate(Vector3.right * _speed * Time.deltaTime);
                    if (rectTransform.localPosition.x > _boundaryTextEnd)
                    {
                        if (isLooping)
                        {
                            rectTransform.localPosition = Vector3.left * _textPosBegin;
                        }
                        else
                        {
                            break;
                        }
                    }
                    yield return null;
                }
                break;
            case Movement.Right_to_left:
                while (rectTransform.localPosition.x > _boundaryTextEnd)
                {
                    rectTransform.Translate(Vector3.left * _speed * Time.deltaTime);
                    if(rectTransform.localPosition.x < _boundaryTextEnd)
                    {
                        if (isLooping)
                        {
                            rectTransform.localPosition = Vector3.right * _textPosBegin;
                        }
                        else
                        {
                            break;
                        }
                    }
                    yield return null;
                }
                break;
            case Movement.Top_to_bottom:
                while (rectTransform.localPosition.y > _boundaryTextEnd)
                {
                    rectTransform.Translate(Vector3.down * _speed * Time.deltaTime);
                    if(rectTransform.localPosition.y < _boundaryTextEnd)
                    {
                        if (isLooping)
                        {
                            rectTransform.localPosition = Vector3.down * _textPosBegin;
                        }
                        else
                        {
                            break;
                        }
                    }
                    yield return null;
                }
                break;
            case Movement.Bottom_to_top:
                while (rectTransform.localPosition.y < _boundaryTextEnd)
                {
                    rectTransform.Translate(Vector3.up * _speed * Time.deltaTime);
                    if (rectTransform.localPosition.y > _boundaryTextEnd)
                    {
                        if (isLooping)
                        {
                            rectTransform.localPosition = Vector3.up * _textPosBegin;
                        }
                        else
                        {
                            break;
                        }
                    }
                    yield return null;
                }
                break;
        }
    }
}
