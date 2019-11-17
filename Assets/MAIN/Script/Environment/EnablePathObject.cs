using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePathObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _objectToShow;

    public void EnablePath() {
        _objectToShow.SetActive(true);
    }
}
