using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explodepoint : MonoBehaviour
{
    [Header("EndScene")]
    [SerializeField] private GameObject _panel;

    [Header("Old")]
    public SoundManager soundManager;
    public GameObject bubbleRight;
    public GameObject bubbleLeft;
    public Button reset;
    public Button quit;

    private BoxCollider2D box;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        Breakpoint.OnHitted += OffTriggered;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent<Player>(out var player)) return;

        _panel.SetActive(true);

        //if (player.hasHitted)
        //{
        //    SoundManager.OnGameOver?.Invoke();
        //    //soundManager.Stop(SoundType.Move);
        //    //soundManager.Play(SoundType.Tumble);
        //    player.TruckDestroyed();
        //    StartCoroutine(DisplayEndGameMessage());
        //}

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
        yield return new WaitForSeconds(1f);
        reset.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
    }
}
