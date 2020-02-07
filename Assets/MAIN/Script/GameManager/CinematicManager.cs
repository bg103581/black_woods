﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicManager : MonoBehaviour
{
    [SerializeField]
    private Animator _crossFade;
    [SerializeField]
    private int _sceneNumber;
    private DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManager>();
    }

    private void Update() {
        if (dialogueManager.isReadyForNextScene) {
            StartCoroutine("SwitchSceneCinematic");
        }
    }

    IEnumerator SwitchSceneCinematic() {
        _crossFade.SetTrigger("crossFadeTrigger");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(_sceneNumber);
    }
}
