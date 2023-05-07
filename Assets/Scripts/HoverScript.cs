using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Color hoverColor = new Color(0.8f,0.675f,0.45f), originalColor;
    TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        originalColor = textMeshPro.color;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        textMeshPro.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textMeshPro.color = originalColor;
    }
}
