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

    [SerializeField] int maxEscapeValue;

    [SerializeField] bool isOver;
    // Start is called before the first frame update
    private void Awake()
    {
        Dialogue.dialogueCheck = false;
        Time.timeScale = 1f;
    }
    void OnEnable()
    {
        isOver = false;
        kapanisColor = kapanis.color;
        //kapanisLerp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log("aaa");
        // baslangictaki acilis
        
        if(isOver)
        {
            kapanisLerp += Time.deltaTime * 0.5f;
            if(kapanisLerp > 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
}
