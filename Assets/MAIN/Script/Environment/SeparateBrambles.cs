using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SeparateBrambles : MonoBehaviour
{
    [SerializeField]
    private Transform firstBramble;
    [SerializeField]
    private Transform secondBramble;

    [SerializeField]
    private Transform firstEndPos;
    [SerializeField]
    private Transform secondEndPos;

    [SerializeField]
    private float doDuration;

    private bool isHit = false;

    public void OnBecHit() {
        Debug.Log("HIT BY DOTS BEC");
        if (!isHit) {
            firstBramble.DORotate(firstEndPos.rotation.eulerAngles, doDuration);
            secondBramble.DORotate(secondEndPos.rotation.eulerAngles, doDuration);
            isHit = true;
        }
    }
}
