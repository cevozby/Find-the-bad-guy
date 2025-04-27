using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI soulsCount;

    [SerializeField] UnityEvent gameOverEvent;

    [SerializeField] Image kapanis;
    Color kapanisColor;
    [Range(0f, 1f)]
    [SerializeField] float kapanisLerp =1;

    public static int maxEscapeValue;

    [SerializeField] bool isOver;

    public static string level;
    // Start is called before the first frame update
    private void Awake()
    {
        EscapeCalculate();
        Dialogue.dialogueCheck = false;
        Time.timeScale = 1f;
    }


    void OnEnable()
    {
        isOver = false;
        kapanisColor = kapanis.color;
        //kapanisLerp = 1;
        Points.souls = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // baslangictaki acilis
        
        if(isOver)
        {
            kapanisLerp += Time.deltaTime * 0.5f;
            if(kapanisLerp > 1)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        else
            kapanisLerp -= Time.deltaTime * 0.5f;
        kapanisLerp = Mathf.Clamp(kapanisLerp, -0.01f, 1.1f);

        kapanis.color = new Color(kapanisColor.r, kapanisColor.g, kapanisColor.b, kapanisLerp);
        

        soulsCount.text = Points.souls.ToString();
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
        if (Points.escapeSouls >= maxEscapeValue)
        {
            gameOverEvent?.Invoke();
            isOver = true;
            Points.escapeSouls = 0;
        }
    
    }

    void EscapeCalculate()
    {
        if(level == "Easy")
        {
            maxEscapeValue = 5;
        }
        else if (level == "Medium")
        {
            maxEscapeValue = 10;
        }
        else if (level == "Hard")
        {
            maxEscapeValue = 15;
        }
        //Debug.Log(maxEscapeValue);
    }

}
