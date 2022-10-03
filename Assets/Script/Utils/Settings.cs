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
        BGMStart = 0,
        BGMGame = 1,
        BGMEnd = 2,
        Move = 3,
        Jump = 4,
        Tumble = 5,
        TreeCry = 6,
        TreeFall = 7,
        TreeSpirit = 8,
        HouseDestroyed = 9
    }

    public enum SfxType
    {
        Bgm = 0,
        Tree = 1,
        House = 2,
        Tractor = 3
    }
}
