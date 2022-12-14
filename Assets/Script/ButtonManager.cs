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
        if(PlayerPrefs.HasKey("AudioVolume"))
            audioSlider.value = PlayerPrefs.GetFloat("AudioVolume");
        audioMixer.SetFloat("Volume", audioSlider.value);
        
        
    }


    public void EasyLevel()
    {
        GameManager.level = "Easy";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MediumLevel()
    {
        GameManager.level = "Medium";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HardLevel()
    {
        GameManager.level = "Hard";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Points.souls = 0;
        Points.escapeSouls = 0;
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
