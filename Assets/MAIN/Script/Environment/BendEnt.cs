using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class BendEnt : MonoBehaviour
{
    [SerializeField]
    private Transform bendLeft;

    [SerializeField]
    private Transform Strix;
    [SerializeField]
    private Transform Dots;
    [SerializeField]
    private Transform Ent;

    private bool isTriggered = false;
    private bool DotsIsIn = false;
    private bool StrixIsIn = false;

    private void OnTriggerEnter(Collider other) {
        if (!isTriggered) {
            if (Ent.GetComponent<Usable>().isDetected) {
                if (Dots.GetComponent<Dots>().isOnStrixHead) {
                    StartCoroutine(Bend());
                } else {
                    if (other.gameObject.name == "Dots") {
                        DotsIsIn = true;
                        Debug.Log("DOTS IN");
                    }
                    if (other.gameObject.name == "Strix") {
                        StrixIsIn = true;
                        Debug.Log("STRIX IN");
                    }

                    if (DotsIsIn && StrixIsIn) {
                        StartCoroutine(Bend());
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Dots") {
            DotsIsIn = false;
        }
        if (other.gameObject.name == "Strix") {
            StrixIsIn = false;
        }
    }

    IEnumerator Bend() {

        Strix.GetComponent<PlayerInput>().PassivateInput();
        Dots.GetComponent<PlayerInput>().PassivateInput();
        
        Ent.transform.DORotate(bendLeft.rotation.eulerAngles, 2);

        yield return new WaitForSeconds(2);

        Strix.GetComponent<PlayerInput>().ActivateInput();
        Dots.GetComponent<PlayerInput>().ActivateInput();

        isTriggered = true;
    }
}
