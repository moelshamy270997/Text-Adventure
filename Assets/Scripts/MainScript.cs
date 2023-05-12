using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI titleTxt;
    [SerializeField] TextMeshProUGUI infoTxt;
    AudioScript audioScript;

    float moveDistance = 0.8f, moveSpeed = 1.0f, zoomSpeed = 0.2f, maxScale = 1.1f, minScale = 0.9f, currentScale;
    bool moveRight = true, zoomIn = true;

    void Start()
    {
        audioScript = GameObject.Find("AudioObject").GetComponent<AudioScript>();
        audioScript.PlayMainMusic();

        currentScale = infoTxt.transform.localScale.x;
    }

    void Update()
    {
        TitleTxtMove();
        InfoTxtMove();
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

    void InfoTxtMove()
    {
        if (zoomIn)
            currentScale += zoomSpeed * Time.deltaTime;
        else
            currentScale -= zoomSpeed * Time.deltaTime;

        if (currentScale > maxScale)
            zoomIn = false;
        else if (currentScale < minScale)
            zoomIn = true;

        infoTxt.transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }
}
