using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class TurnEnt : MonoBehaviour
{
    [SerializeField]
    private Transform RotateLeft;
    [SerializeField]
    private Transform RotateRight;
    [SerializeField]
    private Transform UnbendPos;

    [SerializeField]
    private Transform Strix;
    [SerializeField]
    private Transform Dots;

    private bool isTriggered = false;
    private bool DotsIsIn = false;
    private bool StrixIsIn = false;



    public void TurnLeft() {
      transform.parent.transform.DORotate(RotateLeft.rotation.eulerAngles, 3f);
    }

    private void OnTriggerEnter(Collider collision) {
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

    private void OnTriggerExit(Collider collision) {
        if (collision.gameObject.name == "Dots") {
            DotsIsIn = false;
        }
        if (collision.gameObject.name == "Strix") {
            StrixIsIn = false;
        }
    }

    IEnumerator TurnRight() {
    
        Strix.GetComponent<PlayerInput>().PassivateInput();
        Dots.GetComponent<PlayerInput>().PassivateInput();

        if (Dots.GetComponent<Dots>().isOnStrixHead) {
            Strix.transform.SetParent(transform.parent);
        } else {
            Strix.transform.SetParent(transform.parent);
            Dots.transform.SetParent(transform.parent);
        }

        //yield return new WaitForSeconds(1.5f);

        //transform.parent.transform.DORotate(UnbendPos.rotation.eulerAngles, 3f);

        yield return new WaitForSeconds(2);

        transform.parent.transform.DORotate(RotateRight.rotation.eulerAngles, 3f);

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
