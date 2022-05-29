using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public static int count = 1;

    public SoundManager soundManager;

    public void TreeCry()
    {
        soundManager.Play(SoundType.TreeCry);
    }

    public void TreeFall()
    {
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
