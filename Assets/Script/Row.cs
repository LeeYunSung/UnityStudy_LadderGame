using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : Path
{
    Column firstColumn, secondColumn;

    Vector2 LEFTPOSITION = new Vector2(0,0);
    Vector2 RIGHTPOSITION = new Vector2(100,0);

    public void SetColumn(Column column1, Column column2){
        firstColumn = column1;
        secondColumn = column2;
        firstColumn.RequestConnecting(this);
    }
    public Column GetColumn(Column currentColumn) {
        Column nextColumn = (currentColumn == firstColumn) ? secondColumn : firstColumn;
        return nextColumn;
    }
    public override Vector2 GetPosition(Path path) {
        return (path == firstColumn) ? LEFTPOSITION : RIGHTPOSITION;
    }
    public override Path GetParent(Path path) {
        return this;
    }
}
