using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    Image backgroundImage;
    AudioScript audioScript;

    void Awake()
    {
        backgroundImage = canvas.GetComponentInChildren<Image>();
        audioScript = GameObject.Find("AudioObject").GetComponent<AudioScript>();
    }

    void Start()
    {
        audioScript.PlayGameMusic();
    }

    void Update()
    {
        // TODO: 
    }

    // A Function used to Change the Image of the main Canvas
    // Takes an argument: imageName, which is located in Resources/Images folder 
    void ChangeBackground(string imageName)
    {
        backgroundImage.sprite = Resources.Load<Sprite>("Images/" + imageName);
    }
}
