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
    public GameObject holeStone;
    public GameObject caveBranch;
    public GameObject Dots;
    public GameObject Strix;
    public Transform StrixPos;
    public Transform DotsPos;
    
    private Transform holeStoneTransform;
    private Transform caveBranchTransform;
    private Transform blueFeatherTransform;

    private void Awake() {
        holeStoneTransform = holeStone.transform;
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

        Dots.transform.position = DotsPos.position;
        Dots.transform.rotation = DotsPos.rotation;
        Strix.transform.position = StrixPos.position;
        Strix.transform.rotation = StrixPos.rotation;
        RollingStone.transform.position = RollingStonePos;

        holeStone.transform.position = holeStoneTransform.position;
        caveBranch.transform.position = caveBranchTransform.position;
        blueFeatherTransform.position = blueFeatherTransform.position;

        RollingStone.SetActive(false);
        holeStone.SetActive(true);
        BlueFeather.SetActive(true);
    }
}
