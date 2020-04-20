using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { private set; get; }

    [SerializeField] private GameObject settingUI;
    [SerializeField] private Text personInput;
    [SerializeField] private Button quickButton;

    [SerializeField] private List<Column> columnLineList = new List<Column>();
    [SerializeField] private List<Person> personList = new List<Person>();
    [SerializeField] private List<Result> resultList = new List<Result>();
    
    void Start(){
        Instance = this;
        settingUI.SetActive(true);
    }
    public void ClickStartButton(){
        settingUI.SetActive(false);
        int people = int.Parse(personInput.text);
        MakeLine(people);
    }
    //generate column
    void MakeLine(int people){
        for (int i = 0; i < people; i++){
            columnLineList[i].gameObject.SetActive(true);
            personList[i].gameObject.SetActive(true);
            resultList[i].gameObject.SetActive(true);
            if (i > 0){
                columnLineList[i].MakeRow(columnLineList[i - 1]);
            }
        }
        quickButton.gameObject.SetActive(true);
    }
    public void QuickButton(){
        quickButton.interactable = false;
        foreach(Person person in personList) { 
            if (!person.clicked) {
                person.ClickPerson();
            }
        }
    }
    public Column GetCurrentColumn(int order) {
        return columnLineList[order];
    }
}
