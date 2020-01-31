using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Handles on-click events for menu buttons.
/// </summary>

public class MenuManager : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public Text volumeNumber;
    public Slider volumeSlider;
    public AudioSource musicTheme;
    public GameObject continueCanvas;
    public GameObject menuCanvas;
    public GameObject noSavedDataCanvas;
    public FMODUnity.StudioEventEmitter EventEmitterRef; /// Sound 
    public Animator crossFade;

    #endregion

    #region PRIVATE VARIABLES
    private GameManager gameManager;
    #endregion

    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();

        EventEmitterRef = GetComponent<FMODUnity.StudioEventEmitter>(); //Sound
    }

    private void OnEnable() {
        menuCanvas.SetActive(true);
        continueCanvas.SetActive(false);
        noSavedDataCanvas.SetActive(false);
    }

    #region BUTTON HANDLERS
    public void NewGame() {
        //EventEmitterRef.Play(); //Sound
        StartCoroutine("SwitchScene");
        //SaveSystem.NewGame();
        //gameManager.Initialize();

    }

    public void VolumeUpdate(float volumeValue) {
        volumeNumber.text = Mathf.RoundToInt(volumeValue * 100) + "%";
        musicTheme.volume = volumeSlider.value;
    }

    public void Continue() {
        EventEmitterRef.Play(); // Sound

        try {
            GameData data = SaveSystem.LoadGame();
            gameManager.Collectibles = data.collectibles;
            gameManager.CollectibleState = data.collectibleState;

            continueCanvas.SetActive(true);

        } catch {
            noSavedDataCanvas.SetActive(true);
        }

        menuCanvas.SetActive(false);
    }

    public void LoadScene(int sceneNumber) {
        SceneManager.LoadScene(sceneNumber);
    }
    #endregion

    IEnumerator SwitchScene() {
        crossFade.SetTrigger("crossFadeTrigger");
        yield return new WaitForSeconds(1.5f);
        SaveSystem.NewGame();
        gameManager.Initialize();
    }
}
