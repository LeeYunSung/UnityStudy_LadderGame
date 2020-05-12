using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { private set; get; }

    [SerializeField] private GameObject guideUI1;
    [SerializeField] private GameObject guideUI2;
    [SerializeField] private GameObject resultUI;

    private int people;
    [SerializeField] private Text personInput;
    [SerializeField] private Button quickButton;
    [SerializeField] private Button resultButton;

    [SerializeField] private List<Column> columnLineList = new List<Column>();
    [SerializeField] private List<Person> personList = new List<Person>();

    [SerializeField] private List<TMP_InputField> caseInputList = new List<TMP_InputField>();
    [SerializeField] private List<Text> caseList = new List<Text>();

    [SerializeField] private List<GameObject> resultList = new List<GameObject>();
    [SerializeField] private List<Text> resultTextList = new List<Text>();


    public void Start(){
        Instance = this;

        guideUI1.SetActive(true);
        guideUI2.SetActive(false);
        resultUI.SetActive(false);

        quickButton.interactable = true;
        quickButton.gameObject.SetActive(false);

        personInput.text = "";
        for (int i = 0; i < people; i++) {
            columnLineList[i].Reset();
            columnLineList[i].gameObject.SetActive(false);

            personList[i].Reset();
            personList[i].gameObject.SetActive(false);

            caseInputList[i].text = "";
            caseInputList[i].gameObject.SetActive(false);
            caseList[i].gameObject.SetActive(false);

            resultList[i].gameObject.SetActive(false);
        }
    }

    public void ClickNextButton(){
        guideUI1.SetActive(false);
        guideUI2.SetActive(true);

        //while(personInput.text == "2-9"){
        //    people = int.Parse(personInput.text);
        //}

        people = int.Parse(personInput.text);
        for (int i = 0; i < people; i++){
            caseInputList[i].gameObject.SetActive(true);
        }
    }

    public void ClickStartButton(){
        guideUI2.SetActive(false);
        for(int i = 0; i<people; i++){
            caseList[i].text = caseInputList[i].text;
        }
        MakeLine();
    }

    public void ClickResultButton(){
        resultButton.gameObject.SetActive(false);
        resultUI.SetActive(true);

        QuickButton();
        for (int i = 0; i < people; i++) { 
            resultTextList[i].text = caseList[int.Parse(personList[i].getResult())-1].text;
            resultList[i].gameObject.SetActive(true);
        }
    }

    //generate column
    void MakeLine(){
        for (int i = 0; i < people; i++){
            columnLineList[i].gameObject.SetActive(true);
            personList[i].gameObject.SetActive(true);
            caseList[i].gameObject.SetActive(true);
            if (i > 0){
                columnLineList[i].MakeRow(columnLineList[i - 1]);
            }
        }
        quickButton.gameObject.SetActive(true);
        resultButton.gameObject.SetActive(true);
    }

    public void QuickButton(){
        quickButton.interactable = false;
        for (int i = 0; i < people; i++){
            if (!personList[i].clicked){
                personList[i].ClickPerson();
            }
        }
    }

    public Column GetCurrentColumn(int order) {
        return columnLineList[order];
    }
}
