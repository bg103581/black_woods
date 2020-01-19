using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetZoomFalseInTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "new_camera") {
            CameraControl cameraControl = other.gameObject.GetComponent<CameraControl>();
            cameraControl.isZooming = false;
            cameraControl.MoveToMaxZ(1.5f);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "new_camera") {
            CameraControl cameraControl = other.gameObject.GetComponent<CameraControl>();
            cameraControl.isZooming = true;
        }
    }
}
