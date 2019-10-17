using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickHandlers : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void SaveGame() {
        gameManager.SaveGame();
    }

    public void BackToMenu() {
        SceneManager.LoadScene(0);
    }
}
