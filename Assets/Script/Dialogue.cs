using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI startText;
    [SerializeField] string[] lines;
    [SerializeField] float textSpeed = 0.3f;

    int index, i;

    public static bool dialogueCheck = false;
    bool canClick;

    // Start is called before the first frame update
    void Start()
    {
        dialogueCheck = false;
        i = index;
        startText.text = string.Empty;
        //StartDialogue();
        Invoke(nameof(StartDialogue),1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            if (startText.text == lines[index])
            {
                NextLine();

            }
            else
            {
                StopAllCoroutines();
                startText.text = lines[index];

            }
        }
        //if(index == lines.Length - 1)
        //{
        //    dialogueCheck = true;
        //}
        //if (dialogueCheck)
        //{
        //    gameObject.SetActive(false);
        //}
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
        canClick = true;
    }

    IEnumerator TypeLine()
    {
        
        foreach (char c in lines[index].ToCharArray())
        {
            startText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            startText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            dialogueCheck = true;
            gameObject.SetActive(false);
        }
    }
}
