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

    public List<Column> activeColumnLineList = new List<Column>();
    private List<Person> activedPersonList = new List<Person>();
    public int people;

    void Start(){
        Instance = this;//********************************
        settingUI.SetActive(true);
    }
    public void ClickStartButton(){
        settingUI.SetActive(false);
        people = int.Parse(personInput.text);
        MakeLine();
    }
    void MakeLine(){ 
        for (int i = 0; i < people; i++){
            personList[i].gameObject.SetActive(true);
            resultList[i].gameObject.SetActive(true);
            activedPersonList.Add(personList[i]);
        }
        Column column = columnLineList[0];
        columnLineList[0].gameObject.SetActive(true);
        activeColumnLineList.Add(column);

        for (int i = 1; i < people; i++){
            columnLineList[i].SetPrevColumn(column);
            column = columnLineList[i];
            activeColumnLineList.Add(column);
            columnLineList[i].gameObject.SetActive(true);
        }
        quickButton.gameObject.SetActive(true);
    }
    public void QuickButton(){
        quickButton.interactable = false;
        if (activedPersonList.Count > 0){
            for (int i = 0; i < activedPersonList.Count; i++){
                activedPersonList[i].ClickPerson();
            }
        }
    }
}
