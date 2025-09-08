using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FontController : MonoBehaviour
{
    [Header("¿Qué texto controlo?")]
    public TMP_Text target;

    [Header("Tamaño")]
    public float minSize = 18f;
    public float maxSize = 72f;
    public float step = 4f;

    [Header("Colores para rotar")]
    public List<Color> colors = new List<Color> { Color.white, Color.yellow, Color.cyan, Color.magenta };
    int colorIndex = 0;

    [Header("Fuentes (TMP Font Assets)")]
    public List<TMP_FontAsset> fonts = new List<TMP_FontAsset>();
    int fontIndex = 0;

    public void IncreaseSize()
    {
        if (target == null) return;
        target.fontSize = Mathf.Clamp(target.fontSize + step, minSize, maxSize);
    }

    public void DecreaseSize()
    {
        if (target == null) return;
        target.fontSize = Mathf.Clamp(target.fontSize - step, minSize, maxSize);
    }

    public void NextColor()
    {
        if (target == null || colors.Count == 0) return;
        colorIndex = (colorIndex + 1) % colors.Count;
        target.color = colors[colorIndex];
    }

    public void NextFont()
    {
        if (target == null || fonts.Count == 0) return;
        fontIndex = (fontIndex + 1) % fonts.Count;
        target.font = fonts[fontIndex];
    }

    // Por si usas un Slider para tamaño
    public void SetSize(float value)
    {
        if (target == null) return;
        target.fontSize = Mathf.Clamp(value, minSize, maxSize);
    }
}
