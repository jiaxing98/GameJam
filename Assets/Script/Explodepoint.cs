using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodepoint : MonoBehaviour
{
    private BoxCollider2D box;
    public SoundManager soundManager;
    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        Breakpoint.OnHitted += OffTriggered;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent<Player>(out var player)) return;
        if (player.hasHitted)
        {
            soundManager.Stop(SoundType.Move);
            soundManager.Play(SoundType.Tumble);
            SoundManager.OnGameOver?.Invoke();
            StartCoroutine(WaitForAudioEnd(player));
        }
    }

    public void OffTriggered()
    {
        box.isTrigger = false;
    }

    IEnumerator WaitForAudioEnd(Player player)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(player.gameObject);
    }
}
