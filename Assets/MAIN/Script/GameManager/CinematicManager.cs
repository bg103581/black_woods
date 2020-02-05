using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicManager : MonoBehaviour
{
    [SerializeField]
    private Animator _crossFade;
    [SerializeField]
    private int _sceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SwitchSceneCinematic");
    }

    IEnumerator SwitchSceneCinematic() {
        yield return new WaitForSeconds(4f);
        _crossFade.SetTrigger("crossFadeTrigger");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(_sceneNumber);
    }
}
