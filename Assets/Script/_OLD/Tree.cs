using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Animator _animator;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag(Settings.Tag.PLAYER)) return;
        Fall();
    }

    public async void Fall()
    {
        SoundManager.Instance.Play(Settings.SoundType.TreeFall);
        _animator.SetBool(Settings.Animation.TREE_FALL, true);
        await Task.Delay(500);
        
        SoundManager.Instance.Play(Settings.SoundType.TreeSpirit);
        await Task.Delay(500);
        _renderer.sprite = ResourceManager.LoadSprite("House");
    }
}
