using UnityEngine;

public class DevilVisual : MonoBehaviour
{
    Vector3 lastSize;
    Vector3 firrstSize;
    float lerpValue;
    [SerializeField] GameObject buttonsObject;

    Vector3 firstPos, lastpos;
    void Start()
    {
        lastSize = transform.localScale;
        firrstSize = Vector3.zero;
        transform.localScale = firrstSize;
        
        lerpValue = 0;
        lastpos = new Vector2(0, -108);
        firstPos = transform.localPosition;
        
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
        if(transform.localPosition != lastpos)
        {
            transform.localPosition = Vector3.Lerp(firstPos, lastpos, lerpValue);
        }
    }
}
