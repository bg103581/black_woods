using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;
    [SerializeField]
    private Animator _crossFade;
    [SerializeField]
    private PlayerInput _strixInput;
    [SerializeField]
    private PlayerInput _dotsInput;
    private bool isActive;
    
    void Update()
    {
        if (Input.GetButtonDown("Start")) {
            if (!isActive) {
                Pause();
            }
            else {
                Resume();
            }
        }
    }

    private void Pause() {
        isActive = true;
        _strixInput.PassivateInput();
        _dotsInput.PassivateInput();
        _panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void MainMenu() {
        StartCoroutine("MainMenuCorout");
    }

    public void Resume() {
        isActive = false;
        _strixInput.ActivateInput();
        _dotsInput.ActivateInput();
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
