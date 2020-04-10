using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : Path
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
    public override Vector3 GetPosition(Path path) {
        Path nextPath = (path == firstColumn) ? secondColumn : firstColumn; ;
        Vector3 vector = new Vector3(nextPath.GetComponent<RectTransform>().rect.position.x,
                                     GetComponent<RectTransform>().rect.position.y); 
        return vector;
    }
}
