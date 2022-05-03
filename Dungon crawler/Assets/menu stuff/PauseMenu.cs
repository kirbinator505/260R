using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //created using https://www.youtube.com/watch?v=JivuXdrIHK0&list=PLPV2KyIb3jR4JsOygkHOd2q0CFoslwZOZ&index=3
    
    public BoolSO GameIsPaused;

    public GameObject pauseMenuUI;

    private void Start()
    {
        GameIsPaused.value = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePauseState();
        }
    }

    public void ChangePauseState()
    {
        if (GameIsPaused.value)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused.value = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused.value = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
