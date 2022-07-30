using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceManager
{
    public static Sprite LoadSprite(string spriteName)
    {
        //provide path??
        
        return Resources.Load<Sprite>(spriteName);
    }
}
