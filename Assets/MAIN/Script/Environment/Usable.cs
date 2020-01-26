using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usable : MonoBehaviour
{
    public bool isDetected = false;
    public bool isUsable = false;

    [SerializeField]
    private MeshRenderer _mesh;

    //action when the object is detected with strix's flair
    public void OnDetected() {
        if (!isDetected) {
            //work on flair's fx
            Debug.Log(gameObject.name.ToString() + "detected !");
            isDetected = true;
            _mesh.enabled = true;
        }
    }
}
