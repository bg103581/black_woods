using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public bool isTriggered = false;
    public bool countPlayers;

    [SerializeField]
    private int playerCount = 0;
    private bool strixHasPassed = false;
    private bool dotsHasPassed = false;

    private void OnTriggerEnter(Collider other) {
        if (!countPlayers) {
            if (!isTriggered) {
                if (other.tag == "Player") {
                    isTriggered = true;
                }
            }
        } else {
            if (other.tag == "Player") {

                if (playerCount < 2) {

                    if (((other.name == "Strix") & !strixHasPassed)) {
                        strixHasPassed = true;
                        playerCount++;
                        if ((playerCount == 2) && !isTriggered) {
                            isTriggered = true;
                        }
                    } else {
                        if (((other.name == "Dots") & !dotsHasPassed)) {
                            dotsHasPassed = true;
                            playerCount++;
                            if ((playerCount == 2) && !isTriggered) {
                                isTriggered = true;
                            }
                        }
                    }

                }
            }
        }
    }
}
