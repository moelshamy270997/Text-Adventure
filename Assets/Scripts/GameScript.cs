using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    Image backgroundImage;
    AudioScript audioScript;
    [SerializeField] TextMeshProUGUI storyTxt;
    [SerializeField] TextMeshProUGUI choiceAText;
    [SerializeField] TextMeshProUGUI choiceBText;
    [SerializeField] TextMeshProUGUI choiceCText;
    [SerializeField] TextMeshProUGUI choiceDText;
    enum State {campus, mensa, bib, faculty, sport, toilette, lecture , football, swimming, labor, showering, exam, secret, dead, None, HappyEnd };
    State currentState;
    State previousState;
    State prePreviousState;
    int laborPoints = 0, numberOfMeals = 0;
    bool laborPassed = false, lectureListened = false, sportPlayed = false, eatMeal = false, studying = false;
    void Awake()
    {
        backgroundImage = canvas.GetComponentInChildren<Image>();
        audioScript = GameObject.Find("AudioObject").GetComponent<AudioScript>();
    }

    void Start()
    {
        audioScript.PlayGameMusic();
        currentState = State.campus;
        previousState= State.None;
        prePreviousState = State.None;
        DisplayState();
    }
    void Update()
    {
        // TODO: 
    }

    void DisplayState()
    {
        switch (currentState)
        {
            case State.campus:
                storyTxt.text = "A new day has started. You are now in the Ruhr-University Bochum. You can choose your destination.";
                choiceAText.text = "1) Go to Mensa";
                choiceBText.text = "2) Go to Faculty";
                choiceCText.text = "3) Go to library";
                choiceDText.text = "4) Do sports";
                break;
            case State.mensa:
                storyTxt.text = "You are in the cafeteria . Here you can have healthy food. Until now you ate " + numberOfMeals + " meals. Please don't eat more than 5 meals.";
                choiceAText.text = sportPlayed ? "1) Eat after sport": "1) Eat a meal";
                choiceBText.text = sportPlayed && eatMeal? "": "2) Go to toilette";
                choiceCText.text = sportPlayed && eatMeal ? "": "2) Back to campus";
                choiceDText.text = "";
                break;
            case State.bib:
                storyTxt.text =studying ? "Maybe you should start writing some code as a preparation for your next Game development session." : "You are in the library of the university. The exam period is soon, so start preparing for your exams. You can go to toilet anytime.";
                choiceCText.text = studying ? "" : "3) Drink coffe and study";
                choiceAText.text = "1) Go to toilet";
                choiceBText.text = "2) Back to campus";
                choiceDText.text = "";
                break;
            case State.sport:
                storyTxt.text = "Today is a sunny day . You want sure to do some sport. Here you can either play football or swim. Please choose your favorite.";
                choiceAText.text = "1) Play football";
                choiceBText.text = "2) Go swimming";
                choiceCText.text = "3) Back to campus";
                choiceDText.text = "";
                break;
            case State.faculty:
                storyTxt.text = "This is the faculty of computer science. You can attend a lecture or do some exercises in labor. You have to do both to be able to write the exam!";
                choiceAText.text = "1) Listen to lecture";
                choiceBText.text = "2) Go to labor";
                choiceDText.text = laborPassed && lectureListened? "3) Write an exam" : "";
                choiceCText.text = "4) Back to campus";
                break;
            case State.toilette:
                storyTxt.text = "You are in the toilet now. Do not forget to wash your hands.";
                choiceAText.text = "1) Back outside";
                choiceBText.text = "";
                choiceCText.text = "";
                choiceDText.text = "";
                break;
            case State.lecture:
                storyTxt.text = "You have attended the lecture of Game Development. Please listen carefully to your instructor.";
                choiceAText.text = "1) Back to faculty";
                choiceBText.text = "";
                choiceCText.text = "";
                choiceDText.text = "";
                break;
            case State.labor:
                storyTxt.text = "You are in the labor. Here we practice coding.Until now you have collected " + laborPoints + " exercise points. You need at least 50 points to be allowed to write the exam. You will be surprised if you gain 100 points!";
                choiceAText.text = "1) Get more points";
                choiceBText.text = "2) Back to faculty";
                choiceCText.text = "";
                choiceDText.text = "";
                break;
            case State.exam:
                storyTxt.text = "You have written your exam successfully. You have completed your task. The day came to its end.";
                choiceAText.text = "1) Done for today!";
                choiceBText.text = "";
                choiceCText.text = "";
                choiceDText.text = "";
                break;
            case State.secret:
                storyTxt.text = "You have passed your 'Game Development course' Congratulations!";
                choiceAText.text = "1) Done";
                choiceBText.text = "";
                choiceCText.text = "";
                choiceDText.text = "";
                break;
            case State.football:
                storyTxt.text = "Football is great. When you are finished you can have a shower or go back to campus. ";
                choiceAText.text = "1) Have a shower";
                choiceBText.text = "2) Back to campus";
                choiceCText.text = "";
                choiceDText.text = "";
                break;
            case State.swimming:
                storyTxt.text = "Swimming makes you feel good.";
                choiceAText.text = "1) Have a shower";
                choiceBText.text = "2) Back to campus";
                choiceCText.text = "";
                choiceDText.text = "";
                break;
            case State.showering:
                storyTxt.text = "You are having a fresh shower. Please go back to campus when you are done.";
                choiceAText.text = "1) Back to campus";
                choiceBText.text = "";
                choiceCText.text = "";
                choiceDText.text = "";
                break;
            case State.dead:
                storyTxt.text = "I warned you!";
                choiceAText.text = "1) Game over";
                choiceBText.text = "";
                choiceCText.text = "";
                choiceDText.text = "";
                break;
            case State.HappyEnd:
                storyTxt.text = "It was a good day! You did sport and ate healthy ;) Good Bye";
                choiceAText.text = "1) Done";
                choiceBText.text = "";
                choiceCText.text = "";
                choiceDText.text = "";
                break;
            default:
                break;
        }
        // These statements deactivate all choice texts that aren't containing any texts
        // If you just set the text to be empty, you might still be able to click on the UI element and trigger the event
        choiceBText.gameObject.SetActive(choiceBText.text != "");
        choiceCText.gameObject.SetActive(choiceCText.text != "");
        choiceDText.gameObject.SetActive(choiceCText.text != "");


    }

    public void SelectChoice(int choice)
    {
        prePreviousState = previousState;
        previousState = currentState;

        switch (currentState)
        {
            case State.campus:
                if (choice == 1) {
                    ChangeBackground("mensa");
                    currentState = State.mensa;
                } 
                else if (choice == 2)
                {
                    ChangeBackground("fac");
                    currentState = State.faculty; 
                }
                else if(choice == 3)
                {
                    ChangeBackground("bib");
                    currentState = State.bib;
                } else if(choice == 4)
                {
                    ChangeBackground("sport");
                    currentState = State.sport;
                }
                break;
            case State.mensa:
                if (choice == 1)
                {
                    eatMeal = true;
                    numberOfMeals++;
                    if(sportPlayed && eatMeal)
                    {
                        ChangeBackground("completed");
                        currentState = State.HappyEnd;
                    }
                    if(numberOfMeals > 5)
                    {
                        ChangeBackground("dead");
                        currentState = State.dead;
                    }
                }
                else if (choice == 2)
                {
                    ChangeBackground("wc");
                    currentState = State.toilette;
                }
                else if (choice == 3)
                {
                    ChangeBackground("campus");
                    currentState = State.campus;
                }
                else if (choice == 4)
                {
                   
                }
                break;
            case State.bib:
                if (choice == 1)
                {
                    studying = false;
                    ChangeBackground("wc");
                    currentState = State.toilette;
                }
                else if (choice == 2)
                {
                    studying = false;
                    ChangeBackground("campus");
                    currentState = State.campus;
                }
                else if (choice == 3)
                {
                    studying = true;
                    ChangeBackground("study");
                    currentState = State.bib;
                }
                
                break;
            case State.faculty:
                if (choice == 1)
                {
                    lectureListened = true;
                    ChangeBackground("lecture");
                    currentState = State.lecture;
                }
                else if (choice == 2)
                {

                    ChangeBackground("labor");
                    currentState = State.labor;
                }
                else if (choice == 3)
                {
                    ChangeBackground("campus");
                    currentState = State.campus;
                }
                else if (choice == 4)
                {
                    ChangeBackground("exam");
                    currentState = State.exam;
                    
                }
                break;
            case State.sport:
                if (choice == 1)
                {
                    sportPlayed= true;
                    ChangeBackground("football");
                    currentState = State.football;
                }
                else if (choice == 2)
                {
                    sportPlayed= true;
                    ChangeBackground("schwimmen");
                    currentState = State.swimming;
                }
                else if (choice == 3)
                {
                    ChangeBackground("campus");
                    currentState = State.campus;
                }
                else if (choice == 4)
                {
                   
                }
                break;
            case State.toilette:
                if (choice == 1)
                {
                    if(prePreviousState == State.bib)
                    {
                        ChangeBackground("bib");
                        currentState = State.bib;
                        
                    }
                    else if(prePreviousState == State.mensa)
                    {
                        ChangeBackground("mensa");
                        currentState = State.mensa;
                    }
                    
                }
                
                break;
            case State.lecture:
                if (choice == 1)
                {
                    ChangeBackground("fac");
                    currentState = State.faculty;
                }
               
                break;
            case State.labor:
                if (choice == 1)
                {
                    laborPoints += 10;
                    if(laborPoints >= 50) laborPassed= true;
                    if (laborPoints == 100) {
                        ChangeBackground("passed");
                        currentState = State.secret;
                    }
                    
                } 
                else if(choice == 2)
                {
                    ChangeBackground("fac");
                    currentState = State.faculty;
                }
                break;
            case State.exam:
                if (choice == 1)
                {
                    SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
                    break;
                }
                break;
            case State.secret:
                if (choice == 1)
                {
                    SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
                    break;
                }
                break;
            case State.football:
                if (choice == 1)
                {
                    ChangeBackground("shower");
                    currentState = State.showering;
                }
                else if (choice == 2)
                {
                    ChangeBackground("campus");
                    currentState = State.campus;
                }
                break;
            case State.swimming:
                if (choice == 1)
                {
                    ChangeBackground("shower");
                    currentState = State.showering;
                }
                else if (choice == 2)
                {
                    ChangeBackground("campus");
                    currentState = State.campus;
                }
                break;
            case State.showering:
                if (choice == 1)
                {
                    ChangeBackground("campus");
                    currentState = State.campus;
                }
                break;
            case State.dead:
                if (choice == 1)
                {
                    SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
                    break;
                }
                break;
            case State.HappyEnd:
                if (choice == 1)
                {
                    SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
                    break;
                }
                break;
            default:
                break;
        }

        DisplayState();
    }

    // A Function used to Change the Image of the main Canvas
    // Takes an argument: imageName, which is located in Resources/Images folder 
    void ChangeBackground(string imageName)
    {
        backgroundImage.sprite = Resources.Load<Sprite>("Images/" + imageName);
    }
}
