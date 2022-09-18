using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whipDeactiver : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Deactive", 0.2f);
    }
    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
