using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeatherCount : MonoBehaviour
{
    public TextMeshProUGUI featherCountText;

    private void Update() {
        featherCountText.text = GameManager.Instance.Collectibles.ToString();
    }
}
