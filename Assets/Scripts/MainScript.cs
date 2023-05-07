using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI titleTxt;
    [SerializeField] TextMeshProUGUI infoTxt;
    AudioScript audioScript;

    float moveDistance = 0.8f;
    float moveSpeed = 1.0f;
    bool moveRight = true;

    void Start()
    {
        audioScript = GameObject.Find("AudioObject").GetComponent<AudioScript>();
        audioScript.PlayMainMusic();
    }

    void Update()
    {
        TitleTxtMove();
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    void TitleTxtMove()
    {
        if (moveRight)
            titleTxt.transform.Translate(Vector3.right * moveDistance * Time.deltaTime * moveSpeed);
        else
            titleTxt.transform.Translate(Vector3.left * moveDistance * Time.deltaTime * moveSpeed);

        moveRight = titleTxt.transform.position.x >= 1f ? false :
            titleTxt.transform.position.x <= -1f ? true : moveRight;
    }
}
