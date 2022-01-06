using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionsControl : MonoBehaviour
{
    public Text questionName;
    public Text answerA;
    public Text answerB;
    public Text answerC;
    public Text answerD;

    public Button aButton;
    public Button bButton;
    public Button cButton;
    public Button dButton;

    Questions qt;

    public List<bool> okQuestions;

    public int answer;

    public GameObject bossNPC;

    void Start()
    {
        qt = GetComponent<Questions>();
        for(int i = 0; i < qt.questions.Count; i++)
        {
            okQuestions.Add(false);
        }
        AddQuestions();
    }

    
    void Update()
    {
        
    }

    public void AddQuestions()
    {
        for(int i = 0; i < okQuestions.Count; i++)
        {
            if(okQuestions[i] == false)
            {
                int questionNumber = Random.Range(0, okQuestions.Count);
                if (okQuestions[questionNumber] == false)
                {
                    okQuestions[questionNumber] = true;
                    questionName.text = qt.questions[questionNumber].questionName;
                    answerA.text = qt.questions[questionNumber].answerA;
                    answerB.text = qt.questions[questionNumber].answerB;
                    answerC.text = qt.questions[questionNumber].answerC;
                    answerD.text = qt.questions[questionNumber].answerD;
                    answer = qt.questions[questionNumber].answer;
                }
                else
                {
                    AddQuestions();
                }
                break;
            }
            if(i == okQuestions.Count - 1)
            {
                Debug.Log("Sorular Bitti :)");
                aButton.gameObject.SetActive(false);
                bButton.gameObject.SetActive(false);
                cButton.gameObject.SetActive(false);
                dButton.gameObject.SetActive(false);
                questionName.text = "TEBRİKLER...:)";
            }
        }

        
        
    }

    public void cevapVer(int value)
    {
        if(value == answer)
        {
            AddQuestions();
        }
        else
        {
            Debug.Log("Yanlış Cevap!!!");
        }
    }
}
