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
        else if (collider.gameObject.TryGetComponent<House>(out var house))
        {
            StartCoroutine(HouseDestroyed(house));
        }
    }

    IEnumerator StartTreeFall(Tree tree)
    {
        tree.TreeFall();
        yield return new WaitForSeconds(0.5f);
        tree.TreeSpirit();
        yield return new WaitForSeconds(0.5f);

        hasDestroyed = true;
        tree.gameObject.SetActive(false);
    }

    IEnumerator HouseDestroyed(House house)
    {
        house.HouseDestroyed();
        yield return new WaitForSeconds(0.5f);
        house.gameObject.SetActive(false);
    }
}
