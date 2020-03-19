using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject SettingUI;
    [SerializeField] private Text personInput;
    [SerializeField] private Text winningInput;

    [SerializeField] private List<GameObject> columnLineList = new List<GameObject>();
    [SerializeField] private List<GameObject> personList = new List<GameObject>();
    [SerializeField] private List<GameObject> winningList = new List<GameObject>();

    private int people;
    private int winning;

    void Start(){
        SettingUI.SetActive(true);
    }
    public void ClickStartButton(){
        SettingUI.SetActive(false);
        people = int.Parse(personInput.text);
        winning = int.Parse(winningInput.text);
        MakeLine();
    }
    private void MakeLine(){
        for (int i = 0; i < people; i++){
            List<GameObject> rowLineList = new List<GameObject>();

            columnLineList[i].SetActive(true);
            personList[i].SetActive(true);
            winningList[i].SetActive(true);
        }
    }     
}
