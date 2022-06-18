using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public SoundManager soundManager;
    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void TreeCry()
    {
        soundManager.Play(SoundType.TreeCry);
    }

    public void TreeFall()
    {
        anim.SetBool("Die", true);
        soundManager.Play(SoundType.TreeFall);
    }

    public void TreeSpirit()
    {
        soundManager.Play(SoundType.TreeSpirit);
    }

    public void NoMoreTree()
    {
        soundManager.Stop(SoundType.TreeCry);
    }
}
