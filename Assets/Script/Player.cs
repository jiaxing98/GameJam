using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string DESTROYABLE = "Destroyable";
    public bool hasDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(DESTROYABLE)) return;
        Destroy(collision.gameObject);
        hasDestroyed = true;
    }
}
