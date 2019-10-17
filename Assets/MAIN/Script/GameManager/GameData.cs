using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData {

    public int collectibles;
    public bool[] collectibleState;

    public GameData(GameManager gameManager) {
        collectibles = gameManager.Collectibles;
        collectibleState = gameManager.CollectibleState;
    }
}

