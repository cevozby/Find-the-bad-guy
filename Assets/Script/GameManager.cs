using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI soulsCount;
    [SerializeField]  TextMeshProUGUI escapeSoulsCount;

    [SerializeField] UnityEvent gameOverEvent;

    [SerializeField] Image kapanis;
    Color kapanisColor;
    float kapanisLerp =1;
    // Start is called before the first frame update
    void Start()
    {
        kapanisColor = kapanis.color;
    }

    // Update is called once per frame
    void Update()
    {
        // baslangictaki acilis
        kapanisLerp -= Time.deltaTime *0.5f;
        kapanis.color = new Color(kapanisColor.r, kapanisColor.g, kapanisColor.b, kapanisLerp);


        soulsCount.text = Points.souls.ToString();
        escapeSoulsCount.text = Points.escapeSouls.ToString();
        GameOver();
    }

    public void DestroyGhost()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("Ghost"))
        {
            Destroy(item);
        }
    }

    void GameOver()
    {
        if(Points.escapeSouls >= 3)
        {
            gameOverEvent?.Invoke();
        }
    }
}
