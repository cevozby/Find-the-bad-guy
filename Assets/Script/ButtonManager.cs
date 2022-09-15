using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("AudioVolume"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("AudioVolume", volume);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
