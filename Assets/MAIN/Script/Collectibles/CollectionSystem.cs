using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script should be attached to the collectible prefab and uses GameManager as a parameter.
/// </summary>

public class CollectionSystem : MonoBehaviour
{
    public int CollectibleIndex;

    private GameManager gameManager;

    [SerializeField]
    private Usable _usable;

    private void Awake() {

        gameManager = FindObjectOfType<GameManager>();
        if (!gameManager.CollectibleState[CollectibleIndex]) {
            gameObject.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && _usable.isDetected) {
            gameManager.Collectibles++;
            gameManager.CollectibleState[CollectibleIndex] = false;
            gameObject.SetActive(false);

            Debug.Log("Feather collected. You have " + gameManager.Collectibles + " feathers in total.");
        }
    }
}
