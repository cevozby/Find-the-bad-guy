using UnityEngine;
using UnityEngine.EventSystems;

public class GhostTiming : MonoBehaviour,IPointerClickHandler
{
    Material _material;
    float alpha;
    Transform player;
    
    Flying fly;
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();    
        fly = GetComponent<Flying>();
        _material = GetComponent<SpriteRenderer>().material;
        alpha = _material.color.a;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        

    }

    // Update is called once per frame
    void Update()
    {
        alpha += Time.deltaTime * 0.05f;
        _material.color = new Color(1,1,1, alpha);
        if(alpha >= 1)
        {
            fly.enabled = true;
            
            
            Points.escapeSouls++;
            Points.souls--;
        }
    }
    public void GetDamage()
    {
        alpha -= 0.2f;
        audio.Play();
      
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Vector2.Distance(transform.position, player.position) < 2)
        {
            Debug.Log("vurdu");
            GetDamage();
        }
        Debug.Log("vurdueee");

    }
}
