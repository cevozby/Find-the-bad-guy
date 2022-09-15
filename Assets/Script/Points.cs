using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int points;
    public int maxPoints;

    #region Singleton
    public static Points instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("Points", points);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Points", points);
        maxPoints = PlayerPrefs.GetInt("Points");
    }
}
