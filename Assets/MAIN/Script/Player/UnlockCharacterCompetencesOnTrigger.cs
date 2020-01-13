using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCharacterCompetencesOnTrigger : MonoBehaviour
{
    private enum Competences {DOTS_BEC, DOTS_COOP, DOTS_JUMP_ON_STRIX, STRIX_FLAIR, STRIX_CREUSE, STRIX_COOP, STRIX_CATCH}
    private enum Character {STRIX, DOTS}

    [SerializeField]
    private Character _character;
    [SerializeField]
    private Competences _competenceToUnlock;

    private Strix _strix;
    private Dots _dots;

    private void Start() {
        _strix = FindObjectOfType<Strix>();
        _dots = FindObjectOfType<Dots>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {

            switch(_character) {
                case Character.STRIX:
                    switch(_competenceToUnlock) {
                        case Competences.STRIX_FLAIR:
                            _strix.flairIsUnlock = true;
                            break;
                        case Competences.STRIX_COOP:
                            _strix.coopIsUnlock = true;
                            break;
                        case Competences.STRIX_CREUSE:
                            _strix.creuseIsUnlock = true;
                            break;
                        case Competences.STRIX_CATCH:
                            _strix.catchIsUnlock = true;
                            break;
                        default:
                            Debug.Log("Mauvaise association Character/Competence");
                            break;
                    }
                    break;

                case Character.DOTS:
                    switch(_competenceToUnlock) {
                        case Competences.DOTS_COOP:
                            _dots.coopIsUnlock = true;
                            break;
                        case Competences.DOTS_BEC:
                            _dots.becIsUnlock = true;
                            break;
                        case Competences.DOTS_JUMP_ON_STRIX:
                            _dots.jumpOnStrixIsUnlock = true;
                            break;
                        default:
                            Debug.Log("Mauvaise association Character/Competence");
                            break;
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
