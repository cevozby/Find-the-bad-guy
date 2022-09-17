using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonBarManagement : MonoBehaviour
{
    [SerializeField] Slider demonBar;

    // Start is called before the first frame update
    void Start()
    {
        demonBar.minValue = 0;
        demonBar.maxValue = 10;
        demonBar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        demonBar.value = Points.escapeSouls;
    }
}
