using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UtilTests;

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
            
          //  gameObject.SetActive(false);
            
            Points.escapeSouls++;
            Points.souls--;
        }
        //Eger tek tek hasar veriyor isek
        /*if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out RaycastHit hit,Mathf.Infinity))
            {
                if(hit.transform == transform && Vector2.Distance(transform.position,player.position)<2)
                {
                    GetDamage();
                    Debug.Log("hulooog");
                }
            }
        }*/
    }
    public void GetDamage()
    {
        alpha -= 0.2f;
        //  AudioEffectController.Instance.wilhelm.Play();
        audio.Play();
      
    }
    public void OnPointerClick(PointerEventData eventData)
    {
       // if (eventData.button != PointerEventData.InputButton.Left) return;
        if (Vector2.Distance(transform.position, player.position) < 2)
        {
            Debug.Log("vurdu");
            GetDamage();
        }
        Debug.Log("vurdueee");

    }
}
