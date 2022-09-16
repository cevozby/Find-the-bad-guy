using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackControl : MonoBehaviour
{
    [SerializeField] LayerMask layermask;
    void Start()
    {

    }

    //eðer belirli bir alandaki tüm ruhlara vuruyor isek 
    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 1f, layermask, 0f, 0);
    //        for (int i = 0; i < enemies.Length; i++)
    //        {
    //            enemies[i].GetComponent<GhostTiming>().GetDamage();
    //        }
    //    }
    //}
}
