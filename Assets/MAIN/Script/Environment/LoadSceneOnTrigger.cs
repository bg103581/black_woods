using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTrigger : MonoBehaviour
{
    [SerializeField]
    private Animator _crossFade;
    private bool _isTriggered;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (!_isTriggered) {
                _isTriggered = true;
                StartCoroutine("SwitchSceneEndChapter1");
            }
        }
    }

    IEnumerator SwitchSceneEndChapter1() {
        _crossFade.SetTrigger("crossFadeTrigger");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(3);
    }
}
