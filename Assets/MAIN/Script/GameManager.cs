using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _collectibles = 0;

    public int Collectibles {
        get {
            return _collectibles;
        }

        set {
            if (value > 0) {
                _collectibles = value;
            }
        }
    }
}
