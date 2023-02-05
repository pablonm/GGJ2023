using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanchaRandom : MonoBehaviour
{
    SpriteRenderer sprite;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();    
    }

    void Start()
    {
        StartCoroutine(InfiniteAnimation());
    }

    IEnumerator InfiniteAnimation()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(4f, 6f));
            sprite.enabled = true;
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            sprite.enabled = false;
        }
    }
}
