using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Column : MonoBehaviour
{
    [SerializeField] private List<Row> rowLineList = new List<Row>();
    List<Row> selectedRowLineList = new List<Row>();

    public void MakeRow(Column prevColumn){
        for (int i = 0; i < 3; i++) {
            int random = Random.Range(0, rowLineList.Count);
            if (!rowLineList[random].gameObject.activeSelf) {
                rowLineList[random].gameObject.SetActive(true);
                selectedRowLineList.Add(rowLineList[random]);
            }else i -= 1;
        }
        for (int i = 0; i < selectedRowLineList.Count; i++) {
            selectedRowLineList[i].SetColumn(prevColumn, this);
        }
    }
    public void RequestConnecting(Row row){
        selectedRowLineList.Add(row);
        selectedRowLineList = selectedRowLineList.OrderByDescending(x => x.transform.position.y).ToList();
    }
    public Column Search() {
        //return Search(selectedRowLineList[0]);
        Column column = selectedRowLineList[0].GetColumn(this);
        return column.Search(selectedRowLineList[0]);
    }
    public Column Search(Row row) {
        for (int i = 0; i < selectedRowLineList.Count; i++) {//다음줄 찾는 부분
            if (row == selectedRowLineList[i]) {
                if (i + 1 != selectedRowLineList.Count) {
                    Column column = selectedRowLineList[i + 1].GetColumn(this);//다음줄 넘어가는 부분
                    return column.Search(selectedRowLineList[i + 1]);
                }
            }
        }
        return this;
    }
}




//public Column Search() {
//    prevRow = selectedRowLineList[0];
//    return Search(prevRow);//중복된거 없애기~
//}
//public Column Search(Row row) {
//    int next = 0;
//    for (int i = 0; i < selectedRowLineList.Count; i++) {//다음줄 찾는 부분
//        if (row == prevRow) next = i;
//        else if (row == selectedRowLineList[i]) {
//            next = i + 1;
//            if (next == selectedRowLineList.Count) {
//                break;
//            }
//        }
//        return MoveNextRow(next);
//    }
//    return this;
//}
//private Column MoveNextRow(int index) {
//    Column column = selectedRowLineList[index].GetColumn(this);
//    return column.Search(selectedRowLineList[index]);
//}