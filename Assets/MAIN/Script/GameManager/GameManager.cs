using UnityEngine;

public class GameManager : GenericSingleton<GameManager>
{
    private int _collectibles;
    public bool[] CollectibleState;

    public override void Awake() {

        Initialize();
    }

    public int Collectibles {
        get {
            return _collectibles;
        }

        set {
            if (value >= 0) {
                _collectibles = value;
            }
        }
    }

    public void SaveGame() {
        SaveSystem.SaveGame(this);
    }

    public void Initialize() {

        Collectibles = 0;

        CollectibleState = new bool[3];

        for (int i = 0; i < 3; i++) {
            CollectibleState[i] = true;
        }
    }

    private void OnPopupAide() {
        Debug.Log("popup");
    }
}
