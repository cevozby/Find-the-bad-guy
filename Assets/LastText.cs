using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastText : MonoBehaviour
{
    TMPro.TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TMPro.TextMeshProUGUI>();
        scoreText.text = "Score\n" + Points.souls;
    }
}
