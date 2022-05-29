using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public SoundManager soundManager;

    public void HouseDestroyed()
    {
        soundManager.Play(SoundType.HouseCrashed);
    }
}
