using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [Range(0f, 1f)]
    [SerializeField] float kapanisLerp =1;

    bool isOver;
    // Start is called before the first frame update
    private void Awake()
    {
        Dialogue.dialogueCheck = false;
    }
    void Start()
    {
        isOver = false;
        kapanisColor = kapanis.color;
        kapanisLerp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // baslangictaki acilis
        kapanisLerp = Mathf.Clamp(kapanisLerp,-0.01f, 1.01f);
        if(isOver)
        {
            kapanisLerp += Time.deltaTime * 0.5f;
            if(kapanisLerp > 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else
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
            isOver = true;
            Points.escapeSouls = 0;
        }
    }
}
