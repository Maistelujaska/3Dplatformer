using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    public static bool gamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject winScreen;
    public GameObject deathScreen;
    public int lastScene;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            WinGame();
        }
    }

    

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Resume();
        AudioManager.Instance.PlayMusic("Theme");
    }

    public void WinGame()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        
    }

    public void GameEnd()
    {
        deathScreen.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void OnStartClick(int sceneIntToLoad)
    {
        SceneManager.LoadScene(sceneIntToLoad);
        lastScene = sceneIntToLoad;
        Resume();
        AudioManager.Instance.PlayMusic("Theme");
    }

    public void MenuReturn()
    {
        lastScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
        Resume();
        AudioManager.Instance.PlayMusic("Theme");
    }

    public void ReturnToLastLevel()
    {
        SceneManager.LoadScene(lastScene);
        Resume();
        AudioManager.Instance.PlayMusic("Theme");
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
