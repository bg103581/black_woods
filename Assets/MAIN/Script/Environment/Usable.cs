using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usable : MonoBehaviour
{
    public bool isDetected = false;
    public bool isUsable = false;

    private SpriteRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    //action when the object is detected with strix's flair
    public void OnDetected() {
        if (!isDetected) {
            //work on flair's fx
            Debug.Log(gameObject.name.ToString() + "detected !");
            isDetected = true;
            _renderer.enabled = true;
        }
    }
}
