using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string DESTROYABLE = "Destroyable";
    public bool hasDestroyed = false;
    public bool hasHitted = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("something enter");
        if (!collider.gameObject.CompareTag(DESTROYABLE)) return;
        if (collider.gameObject.TryGetComponent<Tree>(out var tree))
        {
            StartCoroutine(StartTreeFall(tree));
        }
    }

    IEnumerator StartTreeFall(Tree tree)
    {
        Tree.count--;
        if (Tree.count > 0) tree.TreeCry();
        else tree.NoMoreTree();

        tree.TreeFall();
        yield return new WaitForSeconds(2.5f);
        tree.TreeSpirit();
        yield return new WaitForSeconds(1.5f);

        hasDestroyed = true;
        tree.gameObject.SetActive(false);
    }
}
