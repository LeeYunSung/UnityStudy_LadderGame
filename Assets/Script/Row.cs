using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private Column firstColumn, secondColumn;
    
    public void SetColumn(Column column1, Column column2){
        firstColumn = column1;
        secondColumn = column2;

        firstColumn.RequestConnecting(this);
        secondColumn.RequestConnecting(this);
    }
    public void GetColumn(int index, Column currentColumn) {
        if(currentColumn == firstColumn){
            secondColumn.Search(++index);
        }
        else firstColumn.Search(++index);
    }
}
