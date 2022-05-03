using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CreateBaseSave : MonoBehaviour
{
    public UnityEvent createBaseSave, loadSave;
    public BoolSO isGamePlayed;
    public SaveAndLoad saveAndLoad;
    private WaitForSeconds delay = new WaitForSeconds(0.1f);
    public void Awake()
    {
        if (isGamePlayed.value == false)
        {
            createBaseSave.Invoke();
            isGamePlayed.value = true;
        }
        else
        {
            saveAndLoad.LoadGameState();
        }
    }

    public void SaveToMenu()
    {
        saveAndLoad.SaveGameState();
        StartCoroutine(ToMenu());

    }

    public void SaveToQuit()
    {
        saveAndLoad.SaveGameState();
        StartCoroutine(Quit());
    }

    IEnumerator Quit()
    {
        yield return delay;
        Application.Quit();
    }

    IEnumerator ToMenu()
    {
        yield return delay;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
