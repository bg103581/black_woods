using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateObject : MonoBehaviour
{
    [SerializeField]
    private Animator _crossFadeReverse;
    [SerializeField]
    private GameObject BlueFeather;
    [SerializeField]
    private GameObject RollingStone;
    
    private Vector3 RollingStonePos;
    private bool canCrossFade = true;

    [Header("RESET OBJECTS")]
    public GameObject warren;
    public GameObject caveBranch;
    public GameObject Dots;
    public GameObject Strix;
    public Transform StrixPos;
    public Transform DotsPos;
    public Transform _strixHead;


    private Transform warrenTransform;
    private Transform caveBranchTransform;
    private Transform blueFeatherTransform;

    private void Awake() {
        warrenTransform = warren.transform;
        caveBranchTransform = caveBranch.transform;
        blueFeatherTransform = BlueFeather.transform;
        RollingStonePos = RollingStone.transform.position;
    }

    private void Update() {
        if (!BlueFeather.activeInHierarchy) {
            if (!RollingStone.activeInHierarchy) {
                RollingStone.SetActive(true);
            }
        }
    }

    public void CollisionDetected(ChildCollision child, Collision collision) {
        RigidbodyConstraints childConstraints = child.gameObject.GetComponent<Rigidbody>().constraints;
        if (childConstraints != RigidbodyConstraints.FreezeAll) {
            if (collision.gameObject.tag == "Player") {
                StartCoroutine(Reset());
            }
        }
    }

    public void TriggerDetected(ChildCollision child, Collider other) {
        RigidbodyConstraints childConstraints = child.gameObject.GetComponent<Rigidbody>().constraints;
        if (other.gameObject.tag == "caveBranch") {
            Debug.Log("BRANCH DETECTED");
            child.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    IEnumerator Reset() {

        canCrossFade = false;

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            Physics.IgnoreCollision(player.GetComponent<Collider>(), RollingStone.GetComponent<Collider>());
            player.GetComponent<PlayerInput>().PassivateInput();
        }

        _crossFadeReverse.SetTrigger("crossFadeTrigger");
        
        yield return new WaitForSeconds(1);

        if (Dots.GetComponent<Dots>().isOnStrixHead) {
            Dots.transform.position = _strixHead.position;
        } else {
            Dots.transform.position = DotsPos.position;
            Dots.transform.rotation = DotsPos.rotation;
        }
        Strix.transform.position = StrixPos.position;
        Strix.transform.rotation = StrixPos.rotation;
        RollingStone.transform.position = RollingStonePos;

        warren.transform.position = warrenTransform.position;
        caveBranch.transform.position = caveBranchTransform.position;
        blueFeatherTransform.position = blueFeatherTransform.position;

        RollingStone.SetActive(false);
        warren.SetActive(true);
        BlueFeather.SetActive(true);

        yield return new WaitForSeconds(1);

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            Physics.IgnoreCollision(player.GetComponent<Collider>(), RollingStone.GetComponent<Collider>(), false);
            player.GetComponent<PlayerInput>().ActivateInput();
        }

        canCrossFade = true;
    }
}
