using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffectController : MonoBehaviour
{
    public static AudioEffectController Instance { get; private set; }
    public AudioSource gulme, wilhelm;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
