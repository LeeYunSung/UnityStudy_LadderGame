using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Column : MonoBehaviour
{
    [SerializeField] public List<Row> rowLineList = new List<Row>();
    public List<Row> activedRowLineList = new List<Row>();
    public List<Row> sortedList = new List<Row>();

    void Start() {
        if (rowLineList.Count != 0) {
            for (int i = 0; i < 5; i++) {
                int random = Random.Range(0, 8);
                rowLineList[random].gameObject.SetActive(true);
                activedRowLineList.Add(rowLineList[random]);
            }
        }
    }
    public void SetPrevColumn(Column column){
        Column prevColumn = column;
        AddRowLine(prevColumn);
    }
    void AddRowLine(Column prevColumn) {
        while (prevColumn.activedRowLineList.Count != 0) {
            for (int i = 0; i < prevColumn.activedRowLineList.Count; i++){
                activedRowLineList.Add(prevColumn.activedRowLineList[i]);
            }
        }
        sortedList = activedRowLineList.OrderBy(x => x.transform.position.y).ToList();
    }
    /// <summary>
    /// 1. activedRowLineList[0] 주기
    /// 2. 걔가 내꺼면 왼쪽 라인으로 이동하고, 걔가 오른쪽꺼면 오른쪽 라인으로 이동(그 Column 클래스가 다시 탐색)
    /// 3. activedRowLineList에 있는 애중에 현재 가로줄다 x값이 큰 애 내놓기
    /// 4. 2번부터 다시 반복
    /// </summary>
    public void Search(int index){
        //int currentRowIndex = index;
        //if(index < activedRowLineList.Count) {
        //    Row row = activedRowLineList[index];
        //    if (row.GetComponentInParent<Column>() == this){
        //        Search(++index);
        //    }
        //    else 

        //    if (row.transform.position.x){

        //    }
        //}
    }
}
