using UnityEngine;

public class DevilVisual : MonoBehaviour
{
    Vector3 lastSize;
    Vector3 firrstSize;
    float lerpValue;
    [SerializeField] Transform dialoguePanel;
    [SerializeField] GameObject buttonsObject;
    public int nextSceneIndex;


    void Start()
    {
        firrstSize = Vector3.zero;
        transform.localScale = firrstSize;
        lastSize = Vector3.one * 7;
        lerpValue = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
            
        if (lerpValue > 2) return;
        lerpValue += Time.deltaTime * 0.5f;
        transform.localScale = Vector3.Lerp(firrstSize,lastSize,lerpValue);
        if (lerpValue >= 1)
        {
            buttonsObject.SetActive(true);
        }
    }
}
