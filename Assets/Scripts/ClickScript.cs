using UnityEngine.EventSystems;
using UnityEngine;

public class ClickScript : MonoBehaviour, IPointerClickHandler
{
    AudioScript audioScript;

    void Awake()
    {
        audioScript = audioScript ? audioScript : GameObject.Find("AudioObject").GetComponent<AudioScript>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioScript.PlaySFX();
    }
}
