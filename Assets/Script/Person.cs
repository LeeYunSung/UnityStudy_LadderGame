using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Person : MonoBehaviour {
    public int ORDER;
    private bool clicked = false;
    const float SPEED = 200;

    [SerializeField] private GameObject emptyObject;

    public void ClickPerson() {
        if (clicked != true) {
            clicked = true;
            transform.parent.transform.GetComponent<GridLayoutGroup>().enabled = false;
            transform.GetComponent<EventTrigger>().enabled = false;

            Column currentColumn = GameController.Instance.GetCurrentColumn(ORDER);
            List<Path> path = currentColumn.Search();

            emptyObject.transform.parent = transform.parent;
            //StartCoroutine(Move(path));
        }
    }
    /*
    IEnumerator Move(List<Path> path) {
        Debug.Log(path.Count);
        for (int i = 0; i < path.Count; i++) {
            if (i + 1 < path.Count) {
                transform.parent = path[i].transform;
                Vector3 movePosition = path[i].GetPosition(path[i + 1]);//이동경로중의 좌표를 받아와서 움직이
                Debug.Log(movePosition);
                transform.position = movePosition;
                yield return new WaitForSeconds(1);
                //while (movePosition != transform.position) {
                //    yield return null;
                //    transform.position = Vector3.MoveTowards(transform.position, movePosition, Time.deltaTime * SPEED);
                //    //    transform.position = movePosition;
                //    //yield retuDrn new WaitForSeconds(2f);
                //}
            }
        }
    }
    */
}
