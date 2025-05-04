using UnityEngine;
using UnityEngine.EventSystems;

public class GhostTiming : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] GhostType ghostType;

    Material _material;
    float alpha;
    Transform player;
    
    Flying fly;
    AudioSource ghostAudio;
    void Start()
    {
        ghostAudio = GetComponent<AudioSource>();
        fly = GetComponent<Flying>();
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        alpha += Time.deltaTime * ghostType.regeneration;
        _material.color = new Color(ghostType.ghostColor.r, ghostType.ghostColor.g, ghostType.ghostColor.b, alpha);
        if(alpha >= 1)
        {
            fly.enabled = true;
            
            
            Points.escapeSouls++;
            Points.souls--;
        }
    }
    public void GetDamage(float extraDamage)
    {
        alpha -= (ghostType.damage + extraDamage);
        ghostAudio.Play();
      
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Vector2.Distance(transform.position, player.position) < 2)
        {
            //GetDamage();
        }

    }

    public void SetGhost(GhostType ghostType)
    {
        this.ghostType = ghostType;
        
        _material = GetComponent<SpriteRenderer>().material;
        _material.color = new Color(ghostType.ghostColor.r, ghostType.ghostColor.g, ghostType.ghostColor.b, ghostType.ghostColor.a);
        alpha = _material.color.a;
    }
}
