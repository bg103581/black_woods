using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour
{
    [SerializeField]
    private Animator _crossFade;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            StartCoroutine("EndGame");
        }
    }

    IEnumerator EndGame() {
        _crossFade.SetTrigger("crossFadeTrigger");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(9);
    }
}
