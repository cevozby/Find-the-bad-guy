using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilTests;
public class Flying : MonoBehaviour
{
   
    GhostTiming timing;
    Vector3 bas, pik, lastpos;
    float lerpvalue;
    void Start()
    {
        timing = GetComponent<GhostTiming>();
        timing.enabled = false;
        bas =transform.position;
        pik = new Vector3(transform.position.x - 10, transform.position.y + 3, transform.position.z);
        lastpos = new Vector3(transform.position.x +4, transform.position.y + 6, transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        lerpvalue += Time.deltaTime;
        Vector3 a= Vector3.Lerp(bas, pik, lerpvalue);
        Vector3 b= Vector3.Lerp(pik, lastpos, lerpvalue);
        transform.position = Vector3.Lerp(a, b, lerpvalue);
        if (lerpvalue > 1)
            Destroy(gameObject);
    }
}
