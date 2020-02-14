using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    [SerializeField]
    private GameObject BlueFeather;
    [SerializeField]
    private GameObject RollingStone;
    
    private Vector3 RollingStonePos;

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
                Reset();
            } else {
                
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

    private void Reset() {

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
    }
}
