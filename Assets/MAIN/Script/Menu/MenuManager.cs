using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text VolumeNumber;
    public Slider Volume;
    public AudioSource MusicTheme;
    public GameObject MenuCanvas;
    public GameObject SettingsCanvas;

    public void NewGame() {
        SceneManager.LoadScene(1);
    }

    public void VolumeUpdate(float VolumeValue) {
        VolumeNumber.text = Mathf.RoundToInt(VolumeValue * 100) + "%";
        MusicTheme.volume = Volume.value;
    }
}
