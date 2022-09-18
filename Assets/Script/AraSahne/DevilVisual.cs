using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DevilVisual : MonoBehaviour
{
    Vector3 lastSize;
    Vector3 firrstSize;
    float lerpValue;
    [SerializeField] Transform dialoguePanel;
    //[SerializeField] Image kapanis;
    //float kapanisLerp;
    //bool controller;
    //Color kapanisColor;
    [SerializeField] GameObject buttonsObject;
    public int nextSceneIndex;
    void Start()
    {
        firrstSize = Vector3.zero;
        transform.localScale = firrstSize;
        lastSize = Vector3.one * 7;
        lerpValue = 0;
      //  kapanisColor = kapanis.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Dialogue.dialogueCheck)
        //{
        //    kapanisLerp += Time.deltaTime;
        //    kapanis.color = new Color(kapanisColor.r, kapanisColor.g, kapanisColor.b, kapanisLerp);
        //    if(kapanisLerp > 1)
        //    {
        //        Dialogue.dialogueCheck = false;
        //        SceneManager.LoadScene(nextSceneIndex);
        //    }
        //}
            
        if (lerpValue > 2) return;
        lerpValue += Time.deltaTime * 0.5f;
        transform.localScale = Vector3.Lerp(firrstSize,lastSize,lerpValue);
        if (lerpValue >= 1)
        {
            buttonsObject.SetActive(true);
            //dialoguePanel.gameObject.SetActive(true);
            //dialoguePanel.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, lerpValue - 1);
        }
    }
}
