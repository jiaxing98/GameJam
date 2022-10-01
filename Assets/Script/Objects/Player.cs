using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    //private void OnTriggerEnter2D(Collider2D collider)
    //{
    //    //Debug.Log("something enter");
    //    if (!collider.gameObject.CompareTag(Settings.Tag.DESTROYABLE)) return;
    //    if (collider.gameObject.TryGetComponent<Tree>(out var tree))
    //    {
    //        //Debug.Log("hit tree");
    //        tree.Fall();
    //    }
    //    else if (collider.gameObject.TryGetComponent<House>(out var house))
    //    {
    //        StartCoroutine(HouseDestroyed(house));
    //    }
    //}

    //public void TruckDestroyed()
    //{
    //    _animator.SetBool("Destroyed", true);
    //    Settings.soundManager.Play(Settings.SoundType.Tumble);
    //}

    IEnumerator HouseDestroyed(House house)
    {
        house.HouseDestroyed();
        yield return new WaitForSeconds(1f);
        house.gameObject.SetActive(false);
    }
}
