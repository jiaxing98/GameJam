using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> stones;

    // Start is called before the first frame update
    void Start()
    {
        Snowball.OnHitted += HideAllStones;
    }

    private void HideAllStones()
    {
        stones.ForEach(x => x.SetActive(false));
    }
}
