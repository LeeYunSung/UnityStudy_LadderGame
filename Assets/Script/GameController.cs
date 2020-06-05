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
    [SerializeField] private GameObject guideUI3;
    [SerializeField] private GameObject resultUI;

    private int people;
    [SerializeField] private Text personInput;
    [SerializeField] private Button quickButton;
    [SerializeField] private Button resultButton;

    [SerializeField] private List<Column> columnLineList = new List<Column>();

    [SerializeField] private List<Person> personList = new List<Person>();
    [SerializeField] private List<TMP_InputField> personNameList = new List<TMP_InputField>();

    [SerializeField] private List<TMP_InputField> caseInputList = new List<TMP_InputField>();
    [SerializeField] private List<Text> caseSetList = new List<Text>();

    [SerializeField] private List<Text> resultPersonNameTextList = new List<Text>();
    [SerializeField] private List<GameObject> resultList = new List<GameObject>();
    [SerializeField] private List<Text> resultTextList = new List<Text>();


    public void Restart(){
        Instance = this;

        guideUI1.SetActive(true);
        resultUI.SetActive(false);
        quickButton.gameObject.SetActive(false);

        personInput.text = "";
        for (int i = 0; i < people; i++) {
            columnLineList[i].Reset();
            personList[i].Reset();

            personNameList[i].text = "";
            caseInputList[i].text = "";
            caseSetList[i].text = "";
            resultPersonNameTextList[i].text = "";
            personNameList[i].gameObject.SetActive(false);
            caseInputList[i].gameObject.SetActive(false);
            caseSetList[i].gameObject.SetActive(false);
            resultList[i].gameObject.SetActive(false);
        }
    }

    void Awake(){
        Instance = this;
        guideUI1.SetActive(true);
        guideUI2.SetActive(false);
        resultUI.SetActive(false);
        for (int i = 0; i < resultList.Count; i++){
            resultList[i].gameObject.SetActive(false);
            personList[i].Reset();
        }
    }

    public void ClickPersonNumInputButton(){
        guideUI1.SetActive(false);
        guideUI2.SetActive(true);
        guideUI3.SetActive(false);

        people = int.Parse(personInput.text);
        for (int i = 0; i < people; i++){
            personNameList[i].gameObject.SetActive(true);
        }
    }
    public void ClickPersonNameInputButton(){
        guideUI1.SetActive(false);
        guideUI2.SetActive(false);
        guideUI3.SetActive(true);

        for (int i = 0; i < people; i++){
            caseInputList[i].gameObject.SetActive(true);
        }
    }
    public void ClickbackButtonToNumInputWindow(){
        personInput.text = "";
        guideUI1.SetActive(true);
        guideUI2.SetActive(false);
        resultUI.SetActive(false);
        for (int i = 0; i < resultList.Count; i++) {
            resultList[i].gameObject.SetActive(false);
            personList[i].Reset();
        }
    }
    public void ClickStartButton(){
        guideUI3.SetActive(false);
        quickButton.interactable = true;
      //  quickButton.gameObject.SetActive(false);
        MakeLine();
    }

    public void ClickResultButton(){
        resultButton.gameObject.SetActive(false);
        resultUI.SetActive(true);

        QuickButton();
        for (int i = 0; i < people; i++) {
            resultPersonNameTextList[i].text = personNameList[i].text;
            resultTextList[i].text = caseInputList[int.Parse(personList[i].getResult())-1].text;
            resultList[i].gameObject.SetActive(true);
        }
    }
    
    //generate column
    void MakeLine(){
        for (int i = 0; i < people; i++){
            columnLineList[i].gameObject.SetActive(true);
            personList[i].gameObject.SetActive(true);
            personList[i].FirstSetting(personNameList[i].text);
            caseSetList[i].gameObject.SetActive(true);
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

    public void OpenResult(string result) {
        caseSetList[int.Parse(result) - 1].text = caseInputList[int.Parse(result) - 1].text;
    }
}
