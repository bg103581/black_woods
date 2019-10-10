using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script should be attached to the collectible prefab and uses GameManager as a parameter.
/// </summary>

public class CollectionSystem : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            gameManager.Collectibles++;
            Destroy(this.gameObject);

            Debug.Log("Feather collected. You have " + gameManager.Collectibles + " feathers in total.");
        }
    }
}
