using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Column : Path {
    [SerializeField] private List<Row> rowLineList = new List<Row>();
    List<Row> selectedRowLineList = new List<Row>();

    public void Reset(){
        for (int i = 0; i < rowLineList.Count; i++) {
            if (rowLineList[i].gameObject.activeSelf) {
                rowLineList[i].gameObject.SetActive(false);
            }
        }
        selectedRowLineList.Clear();
    }
    public void MakeRow(Column prevColumn) {
        for (int i = 0; i < 3; i++) {
            int random = Random.Range(0, rowLineList.Count);
            if (!rowLineList[random].gameObject.activeSelf) {
                rowLineList[random].gameObject.SetActive(true);
                selectedRowLineList.Add(rowLineList[random]);
            }
            else i -= 1;
        }
        for (int i = 0; i < selectedRowLineList.Count; i++) {
            selectedRowLineList[i].SetColumn(prevColumn, this);
        }
        selectedRowLineList = selectedRowLineList.OrderByDescending(x => x.transform.position.y).ToList();
    }
    public void RequestConnecting(Row row) {
        selectedRowLineList.Add(row);
        selectedRowLineList = selectedRowLineList.OrderByDescending(x => x.transform.position.y).ToList();
    }

    public List<Path> Search() {
        //return Search(selectedRowLineList[0]);
        Column column = selectedRowLineList[0].GetColumn(this);
        List<Path> path3 = column.Search(selectedRowLineList[0]);
        path3.Insert(0, this);
        return path3;
    }

    public List<Path> Search(Row row) {
        int index = selectedRowLineList.IndexOf(row);
        if (index != -1 && index + 1 != selectedRowLineList.Count) {
            Column column = selectedRowLineList[index + 1].GetColumn(this);//다음 세로줄 넘어가는 부분
            List<Path> path2 = column.Search(selectedRowLineList[index + 1]);
            path2.Insert(0, this);
            path2.Insert(0, row);
            return path2;
        }
        List<Path> path = new List<Path>();
        path.Add(this);
        path.Insert(0, row);
        return path;
    }

    public override Vector2 GetPosition(Path path) {
        return path != null ? path.GetPosition(this) : new Vector2(0, -rectTransform.rect.height / 2);
    }

    public override Path GetParent(Path path) {
        return path != null ? path.GetParent(path) : this;
    }
}