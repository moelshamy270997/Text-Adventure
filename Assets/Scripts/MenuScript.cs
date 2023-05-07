using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject menuListObject;
    [SerializeField] TextMeshProUGUI storyTxt;
    [SerializeField] TextMeshProUGUI choicesTxt;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI volumeTxt;
    AudioScript audioScript;
    bool isActive = false; // a flag variable to detect if the menuList object is active or not

    void Awake()
    {
        audioScript = GameObject.Find("AudioObject").GetComponent<AudioScript>();
        slider.value = audioScript.GetVolume();
        volumeTxt.text = "Vol.: " + (int)(slider.value * 100) + "%";
    }

    public void MenuOnClick()
    {
        if (isActive)
        {
            isActive = false;
            menuListObject.gameObject.SetActive(false);
        }
        else
        {
            isActive = true;
            menuListObject.gameObject.SetActive(true);
        }   
    }

    public void OnSliderValueChange()
    {
        volumeTxt.text = "Vol.: " + (int) (slider.value * 100) + "%";
        audioScript.SetVolume(slider.value);
    }

    public void BackOnClick()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
