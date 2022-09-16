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
    void Update()
    {
        if (!PlayerMovement.gameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Collider[] enemies = Physics.OverlapSphere(transform.position, 1f, layermask);
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<GhostTiming>().GetDamage();
                }
            }
        }
    }
}
