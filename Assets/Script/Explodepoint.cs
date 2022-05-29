using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodepoint : MonoBehaviour
{
    private BoxCollider2D box;
    public SoundManager soundManager;

    public GameObject bubbleRight;
    public GameObject bubbleLeft;

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
            //soundManager.Stop(SoundType.Move);
            //soundManager.Play(SoundType.Tumble);
            //SoundManager.OnGameOver?.Invoke();
            StartCoroutine(DisplayEndGameMessage());
        }

        player.enabled = false;
    }

    public void OffTriggered()
    {
        box.isTrigger = false;
    }

    IEnumerator DisplayEndGameMessage()
    {
        yield return new WaitForSeconds(1f);
        bubbleLeft.SetActive(true);
        yield return new WaitForSeconds(1f);
        bubbleRight.SetActive(true);
    }
}
