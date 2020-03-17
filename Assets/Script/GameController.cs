using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject SettingUI;
    [SerializeField] private InputField personInputField;
    [SerializeField] private InputField winningInputField;

    [SerializeField] private Column columnPrefabs;
    [SerializeField] private Column columns;
    [SerializeField] private Row rowPrefabs;
    [SerializeField] private Row rows;

    private int m_people;
    private int m_winning;

    private const float VERTICAL_MIN = -2.9f;
    private const float VERTICAL_MAX = 3f;

    private float xPosition = 0;

    void Start(){
        SettingUI.SetActive(true);
    }
    public void ClickStartButton(){
        SettingUI.SetActive(false);
        m_people = int.Parse(personInputField.text);
        m_winning = int.Parse(winningInputField.text);
        MakeColumn();
    }

    private void MakeColumn(){
        Column column = Instantiate(columnPrefabs);
        column.transform.parent = columns.transform;

        float yPosition = column.transform.position.y;
        column.transform.position = new Vector2(xPosition, yPosition);

        for (int i = 0; i < m_people - 1; i++)  {
            MakeRow();

            xPosition += 1.7f;
            column = Instantiate(columnPrefabs);
            column.transform.parent = columns.transform;
            column.transform.position = new Vector2(xPosition, yPosition);
        }
    }
    private void MakeRow(){
        for (int j = 0; j < 3; j++) {
            Row row = Instantiate(rowPrefabs);
            row.transform.parent = rows.transform;

            float yPosition = Random.Range(VERTICAL_MIN, VERTICAL_MAX);
            row.transform.position = new Vector2(row.transform.position.x + xPosition, yPosition);
        }
    }
}
