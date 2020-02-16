using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class TurnEnt : MonoBehaviour
{
    [SerializeField]
    private Transform StartPos;
    [SerializeField]
    private Transform EndPos;

    [SerializeField]
    private Transform Strix;
    [SerializeField]
    private Transform Dots;

    private bool isTriggered = false;
    private bool DotsIsIn = false;
    private bool StrixIsIn = false;

    public void TurnLeft() {
      transform.parent.transform.DORotate(StartPos.rotation.eulerAngles, 3f);
    }

    private void OnCollisionEnter(Collision collision) {
        if (!isTriggered) {
            if (Dots.GetComponent<Dots>().isOnStrixHead) {
                StartCoroutine(TurnRight());
                isTriggered = true;
            } else {
                if (collision.gameObject.name == "Dots") {
                    DotsIsIn = true;
                }
                if (collision.gameObject.name == "Strix") {
                    StrixIsIn = true;
                }

                if (DotsIsIn && StrixIsIn) {
                    StartCoroutine(TurnRight());
                    isTriggered = true;
                }
            }
            
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.name == "Dots") {
            DotsIsIn = false;
        }
        if (collision.gameObject.name == "Strix") {
            StrixIsIn = false;
        }
    }

    IEnumerator TurnRight() {
        yield return new WaitForSeconds(0.5f);

        Strix.GetComponent<PlayerInput>().PassivateInput();
        Dots.GetComponent<PlayerInput>().PassivateInput();

        if (Dots.GetComponent<Dots>().isOnStrixHead) {
            Strix.transform.SetParent(transform.parent);
        } else {
            Strix.transform.SetParent(transform.parent);
            Dots.transform.SetParent(transform.parent);
        }

        yield return new WaitForSeconds(1.5f);

        transform.parent.transform.DORotate(EndPos.rotation.eulerAngles, 3f);

        yield return new WaitForSeconds(4f);

        if (Dots.GetComponent<Dots>().isOnStrixHead) {
            Strix.transform.SetParent(null);
        } else {
            Strix.transform.SetParent(null);
            Dots.transform.SetParent(null);
        }

        Strix.GetComponent<PlayerInput>().ActivateInput();
        Dots.GetComponent<PlayerInput>().ActivateInput();
    }
}
