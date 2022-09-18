using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Audio").SetActive(false);
    }
}
