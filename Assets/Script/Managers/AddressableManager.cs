using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class AddressableManager
{
    public static Sprite LoadSprite(string spriteName)
    {
        var assetAddress = $"Assets/Sprite/HouseSprite/{spriteName}.png";
        var sprite = Addressables.LoadAssetAsync<Sprite>(assetAddress);
        return sprite.WaitForCompletion();
    }
}
