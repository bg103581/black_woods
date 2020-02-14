using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usable : MonoBehaviour
{
    public bool isDetected = false;
    public bool isUsable = false;

    [SerializeField]
    private MeshRenderer _mesh;
    [SerializeField]
    private ParticleSystem _blingBling;

    //action when the object is detected with strix's flair
    public void OnDetected() {
        if (tag == "sing_object") {
            if (!isDetected) {
                Debug.Log(gameObject.name.ToString() + "detected !");
                isDetected = true;
                GetComponent<SingReaction>().React();
            }
        } else {
            if (!isDetected) {
                //work on flair's fx
                Debug.Log(gameObject.name.ToString() + "detected !");
                isDetected = true;
                _mesh.enabled = true;
                _blingBling.Stop();
            }
        }
    }
}
