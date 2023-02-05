using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyesAnimation : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 4f));
            GetComponent<Image>().enabled = false;
            yield return new WaitForSeconds(0.5f);
            GetComponent<Image>().enabled = true;
        }
    }
}
