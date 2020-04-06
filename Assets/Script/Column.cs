using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Column : MonoBehaviour
{
    [SerializeField] private List<Row> rowLineList = new List<Row>();
    private List<Row> selectedRowLineList = new List<Row>();

    public void MakeRow(Column prevColumn){
        rowLineList[0].gameObject.SetActive(true);
        selectedRowLineList.Add(rowLineList[0]);
        Debug.Log(selectedRowLineList.Count);
        //for (int i = 0; i < selectedRowLineList.Count; i++){
        //     selectedRowLineList[i].SetColumn(prevColumn, this);
        //}
    //    for (int i = 0; i < 5; i++){
    //        int random = Random.Range(0, rowLineList.Count);//0~8
    //        if (!rowLineList[random].gameObject.activeSelf){
    //            rowLineList[random].gameObject.SetActive(true);
    //            selectedRowLineList.Add(rowLineList[random]);
    //        }
    //        else i += 1;
    //    }
    //    for(int i = 0; i < selectedRowLineList.Count; i++){
    //        selectedRowLineList[i].SetColumn(prevColumn, this);
    //    }
    }
    public void RequestConnecting(Row row){
        selectedRowLineList.Add(row);
        selectedRowLineList = selectedRowLineList.OrderBy(x => x.transform.position.y).ToList();        
    }
    public void Search(int index) {
        if(index >= selectedRowLineList.Count - 1){
            Debug.Log(name);
            return;
        }
        selectedRowLineList[index].GetColumn(index, this);
    }
}