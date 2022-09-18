using UnityEngine;

public class Points : MonoBehaviour
{
    public static int souls;
    public static int escapeSouls;
    public static int maxSouls;

    

    // Start is called before the first frame update
    void Awake()
    {
        souls = 0;
        escapeSouls = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Souls", souls);
        
        //maxSouls = PlayerPrefs.GetInt("Souls");
    }
}
