using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider))]
public class DeathTriggerToDisappear : MonoBehaviour {
    [SerializeField]
    private Animator _crossFadeReverse;
    [SerializeField]
    private Transform _posToRespawn;
    [SerializeField]
    private GameObject FirstSeparateBramblesTrigger;

    private bool canCrossFade = true;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (canCrossFade) {
                StartCoroutine(TriggerCrossFade());
            }
        }
    }

    IEnumerator TriggerCrossFade() {
        canCrossFade = false;

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
            player.GetComponent<PlayerInput>().PassivateInput();
        }

        _crossFadeReverse.SetTrigger("crossFadeTrigger");


        yield return new WaitForSeconds(1);

        if (GameObject.Find("Dots").GetComponent<Dots>().isOnStrixHead) {
            GameObject.Find("Strix").transform.position = _posToRespawn.position;
        } else {
            foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
                player.transform.position = _posToRespawn.position;
            }
        }

        yield return new WaitForSeconds(1);

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>(), false);
            player.GetComponent<PlayerInput>().ActivateInput();
        }

        canCrossFade = true;
    }

    private void Update() {
        if (FirstSeparateBramblesTrigger.GetComponent<SeparateBrambles>().isHit) {
            gameObject.SetActive(false);
        }
    }
}
