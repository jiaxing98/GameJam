using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private CircleCollider2D _collider;

    public static event Action OnHitted;

    private void Start()
    {
        _collider = GetComponent<CircleCollider2D>();

        TriggerPoint.onTractorPassed += AddRigidBody;
    }

    private void AddRigidBody()
    {
        _rigidbody = this.gameObject.AddComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        SoundManager.Instance.StopPlayingSfx(Settings.SfxType.Bgm);
        SoundManager.Instance.StopPlayingSfx(Settings.SfxType.Tractor);
        SoundManager.Instance.PlayTractorSfx(Settings.SoundType.Tumble);
        OnHitted?.Invoke();
    }
}
