using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;
    [SerializeField]
    private Animator _crossFade;
    private bool isActive;
    
    void Update()
    {
        if (Input.GetButtonDown("Start")) {
            if (!isActive) {
                isActive = true;
                _panel.SetActive(true);
                Time.timeScale = 0f;
            }
            else {
                Resume();
            }
        }
    }

    public void MainMenu() {
        StartCoroutine("MainMenuCorout");
    }

    public void Resume() {
        isActive = false;
        _panel.SetActive(false);
        Time.timeScale = 1f;
    }

    IEnumerator MainMenuCorout() {
        Debug.Log("main menu");
        Time.timeScale = 1f;
        _crossFade.SetTrigger("crossFadeTrigger");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
