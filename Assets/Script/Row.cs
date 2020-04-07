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
    }
    public Column GetColumn(Column currentColumn) {
        Column nextColumn = (currentColumn == firstColumn) ? secondColumn : firstColumn;
        return nextColumn;
    }
}
