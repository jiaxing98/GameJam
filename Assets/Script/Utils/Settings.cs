using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings
{
    public struct Tag
    {
        public const string PLAYER = "Player";
        public const string DESTROYABLE = "Destroyable";
    }

    public struct Animation
    {
        public const string TREE_FALL = "Die";
        public const string HOUSE_DESTROYED = "Destroy";
    }

    public enum SoundType
    {
        EasterEgg = 0,
        Move = 1,
        Jump = 2,
        Tumble = 3,
        TreeCry = 4,
        TreeFall = 5,
        TreeSpirit = 6,
        HouseCrashed = 7,
        BGMStart = 8,
        BGMEnd = 9
    }
}
