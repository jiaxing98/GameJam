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
        BGMStart,
        BGMFun,
        BGMSuspense,
        BGMEnd,
        Move,
        Jump,
        Tumble,
        TreeCry,
        TreeFall,
        TreeSpirit,
        HouseDestroyed
    }

    public enum SfxType
    {
        Bgm = 0,
        Tree = 1,
        House = 2,
        Tractor = 3
    }
}
