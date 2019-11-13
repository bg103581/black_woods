using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    public List<GameObject> PopupArray;

    private void Awake() {
        foreach (GameObject popup in GameObject.FindGameObjectsWithTag("popup")) {
            PopupArray.Add(popup);
            popup.SetActive(false);
        }
    }

    public void ShowPopup() {
        if (PopupArray != null) {
            if (PopupArray[0].activeInHierarchy) {
                PopupArray[0].SetActive(false);
            } else {
                PopupArray[0].SetActive(true);
            }
        }
    }

    private void OnEnable() {
        foreach (GameObject popup in PopupArray) {
            popup.SetActive(false);
        }
    }
}
