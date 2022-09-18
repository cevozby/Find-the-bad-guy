using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider audioSlider;

    // Start is called before the first frame update
    void Start()
    {
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("AudioVolume"));
        audioSlider.value = -40;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void RestartButton()
    {
        SceneManager.LoadScene("Hell");
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
    }

    public void SetVolume(float volume)
    {
        
        audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("AudioVolume", volume);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
