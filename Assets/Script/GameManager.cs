using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI soulsCount;
    [SerializeField]  TextMeshProUGUI escapeSoulsCount;

    [SerializeField] UnityEvent gameOverEvent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
