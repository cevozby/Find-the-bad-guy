using System.Collections;
using UnityEngine;

public class CharacterAttackControl : MonoBehaviour
{
    [SerializeField] LayerMask layermask;
    [SerializeField] GameObject whip;
    Vector3 whipDirection;

    private float extraDamage = 0f;
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
                whipDirection = Vector3.zero;
                Collider[] enemies = Physics.OverlapSphere(transform.position, 1f, layermask);
                if(enemies.Length > 0)
                    whip.SetActive(true);
                
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<GhostTiming>().GetDamage(extraDamage);
                    if (i == enemies.Length) break;
                  

                }
                foreach (var item in enemies)
                {
                    whipDirection += item.transform.position;
                }
                whipDirection /= enemies.Length;
                whip.transform.right = (whipDirection - transform.position).normalized;
            }
        }
    }

    public void SetExtraDamage(float extraDamage, float time)
    {
        StartCoroutine(Attack(extraDamage, time));
    }

    IEnumerator Attack(float extraDamage, float time)
    {
        this.extraDamage = extraDamage;
        yield return new WaitForSeconds(time);
        this.extraDamage = 0f;
    }

}
