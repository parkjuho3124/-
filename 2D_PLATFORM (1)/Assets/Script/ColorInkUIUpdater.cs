using UnityEngine;
using TMPro;

public class ColorInkUIUpdater : MonoBehaviour
{
    public TextMeshProUGUI colorInkText;

    void Update()
    {
        colorInkText.text = $"Color Ink: {ColorInkManager.Instance.GetInk()}";
    }
}