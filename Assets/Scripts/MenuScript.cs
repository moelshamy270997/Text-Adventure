using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject menuListObject;
    [SerializeField] GameObject walkthroughObject;
    [SerializeField] TextMeshProUGUI storyTxt;
    [SerializeField] TextMeshProUGUI choicesTxt;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI volumeTxt;
    AudioScript audioScript;
    bool isActive = false; // a flag variable to detect if the menuList object is active or not
    bool walkthroughIsActive = false;

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
            walkthroughIsActive = false;
            menuListObject.gameObject.SetActive(false);
            walkthroughObject.gameObject.SetActive(false);
        }
        else
        {
            isActive = true;
            menuListObject.gameObject.SetActive(true);
        }   
    }

    public void WalkthroughOnClick()
    {
        if (walkthroughIsActive)
        {
            walkthroughIsActive = false;
            walkthroughObject.gameObject.SetActive(false);
        }
        else
        {
            walkthroughIsActive = true;
            walkthroughObject.gameObject.SetActive(true);
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
