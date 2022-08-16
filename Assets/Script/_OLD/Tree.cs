using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Animator _animator;

    private bool _isAnimationCompleted = false;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        if (_isAnimationCompleted)
        {
            _renderer.sprite = AddressableManager.LoadSprite("House");
            gameObject.AddComponent<Rigidbody2D>();
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            _animator.enabled = false;
            _isAnimationCompleted = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag(Settings.Tag.PLAYER)) return;
        Fall();
    }

    public async void Fall()
    {
        SoundManager.Instance.PlayTreeSfx(Settings.SoundType.TreeFall);
        _animator.SetBool(Settings.Animation.TREE_FALL, true);
        await Task.Delay(500);
        
        SoundManager.Instance.PlayTreeSfx(Settings.SoundType.TreeSpirit);
    }

    public void AnimationCompleted()
    {
        _isAnimationCompleted = true;
        var sprite = AddressableManager.LoadSprite("House");
        Debug.Log(sprite.name);
        _renderer.sprite = AddressableManager.LoadSprite("House");
    }
}
