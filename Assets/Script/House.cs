using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public SoundManager soundManager;
    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void HouseDestroyed()
    {
        anim.SetBool("Destroyed", true);
        soundManager.Play(SoundType.HouseCrashed);
    }
}
