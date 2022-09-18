using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.SetActive(true);
        GameObject[] audios = GameObject.FindGameObjectsWithTag("Audio");
        if (audios.Length > 1)
            Destroy(audios[1]);
        DontDestroyOnLoad(this);
    }

}
