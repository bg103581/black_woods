using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usable : MonoBehaviour
{
    public bool isDetected = false;
    public bool isUsable = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //action when the object is detected with strix's flair
    public void OnDetected() {
        if (!isDetected) {
            //work on flair's fx
            Debug.Log(gameObject.name.ToString() + "detected !");
            isDetected = true;
        }
    }
}
