using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string DESTROYABLE = "Destroyable";
    public bool hasDestroyed = false;
    public bool hasHitted = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(DESTROYABLE)) return;
        if(collision.gameObject.TryGetComponent<Tree>(out var tree))
        {
            StartCoroutine(StartTreeFall(tree));
        }
    }

    IEnumerator StartTreeFall(Tree tree)
    {
        tree.TreeFall();
        yield return new WaitForSeconds(2.5f);
        tree.TreeSpirit();
        yield return new WaitForSeconds(1.5f);
        Tree.count--;
        if (Tree.count > 0) tree.TreeCry();
        else tree.NoMoreTree();

        hasDestroyed = true;
        tree.gameObject.SetActive(false);
    }
}
