using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persitent : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
