using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Usable), typeof(SingReaction))]
public class QTESystem : MonoBehaviour
{
    public enum Buttons { A, B, X, Y, error}

    [SerializeField]
    private ParticleSystem _zzz;
    [SerializeField]
    private ParticleSystem _goodNote;
    [SerializeField]
    private ParticleSystem _badNote;

    [SerializeField]
    private GameObject _dots;
    [SerializeField]
    private int _numberButtons;
    [SerializeField]
    private GameObject _qteImage;
    [SerializeField]
    private Image _qte;
    [SerializeField]
    private Sprite[] _buttonSprites;

    private PlayerInput _dotsControls;
    private Dots _dotsScript;
    [HideInInspector]
    public bool success;
    [HideInInspector]
    public bool isDone;
    private Buttons[] _buttonsQTE;
    private Dictionary<Buttons, Sprite> _dicButtonSprite;
    [HideInInspector]
    public Buttons currentButton;
    private int currentIndex = 0;

    private void Start() {
        _dotsControls = _dots.GetComponent<PlayerInput>();
        _dotsScript = _dots.GetComponent<Dots>();

        _dicButtonSprite = new Dictionary<Buttons, Sprite>();
        foreach (Sprite sprite in _buttonSprites) {
            switch(sprite.name) {
                case "sprite_A":
                    _dicButtonSprite.Add(Buttons.A, sprite);
                    break;
                case "sprite_B":
                    _dicButtonSprite.Add(Buttons.B, sprite);
                    break;
                case "sprite_X":
                    _dicButtonSprite.Add(Buttons.X, sprite);
                    break;
                case "sprite_Y":
                    _dicButtonSprite.Add(Buttons.Y, sprite);
                    break;
                default:
                    break;
            }
        }

        InitQTE();
    }

    private void InitQTE() {
        _buttonsQTE = new Buttons[_numberButtons];

        for (int i = 0; i < _numberButtons; i++) {
            int rand = Random.Range(0, 4);
            _buttonsQTE[i] = ChooseButton(rand);
        }

        currentButton = _buttonsQTE[currentIndex];
    }

    private Buttons ChooseButton(int rand) {
        switch(rand) {
            case 0:
                return Buttons.A;
            case 1:
                return Buttons.B;
            case 2:
                return Buttons.X;
            case 3:
                return Buttons.Y;
            default:
                return Buttons.error;
        }
    }

    public void StartQTE() {
        if (!isDone) {
            _qteImage.SetActive(true);
            _qte.sprite = _dicButtonSprite[currentButton];
            _dotsControls.SwitchCurrentActionMap("DotsQTE");
        }
    }

    public void ButtonSuccess() {
        if (currentIndex == _numberButtons - 1) {
            Debug.Log("QTE FINISHED");
            _dotsControls.SwitchCurrentActionMap("Player");
            _qteImage.SetActive(false);
            isDone = true;
            GetComponent<SingReaction>().React();
            GetComponent<Usable>().isDetected = true;

            _zzz.Stop();
            _zzz.gameObject.SetActive(false);
        }
        else if (currentIndex < _numberButtons) {
            Debug.Log("success");
            currentIndex++;
            currentButton = _buttonsQTE[currentIndex];
            _qte.sprite = _dicButtonSprite[currentButton];
            _goodNote.Simulate(0.0f, true, true);
            _goodNote.Play();
        }

        _dotsScript.SetTriggerAnim("isSinging");
    }

    public void ButtonFail() {
        Debug.Log("fail");
        currentIndex = 0;
        _qteImage.SetActive(false);
        _badNote.Simulate(0.0f, true, true);
        _badNote.Play();
        GetComponent<Usable>().isDetected = false;

        InitQTE();
        _dotsControls.SwitchCurrentActionMap("Player");
    }
}
