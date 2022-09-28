using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag(Settings.Tag.PLAYER)) return;
        
        if (!_animator.GetBool(Settings.Animation.TREE_FALL))
        {
            Fall();
        }
        else
        {
            HouseDestroy();
        }
    }

    public async void Fall()
    {
        SoundManager.Instance.PlayTreeSfx(Settings.SoundType.TreeFall);
        _animator.SetBool(Settings.Animation.TREE_FALL, true);
        await Task.Delay(1000);

        _rigidbody = gameObject.AddComponent<Rigidbody2D>();
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        await Task.Delay(2000);
        AfterRespawn();

        SoundManager.Instance.PlayTreeSfx(Settings.SoundType.TreeSpirit);
    }

    public void HouseDestroy()
    {
        SoundManager.Instance.PlayTreeSfx(Settings.SoundType.TreeFall);
        _animator.SetBool(Settings.Animation.HOUSE_DESTROYED, true);
        SoundManager.Instance.PlayTreeSfx(Settings.SoundType.TreeSpirit);
    }

    public void AfterRespawn()
    {
        Destroy(_rigidbody);
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //_animator.enabled = false;
    }
}
