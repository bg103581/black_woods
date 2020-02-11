using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePathObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _objectToHide;

    public void EnablePath() {
        _objectToHide.SetActive(false);
    }
    
}
