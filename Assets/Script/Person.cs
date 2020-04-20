using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Person : MonoBehaviour {
    public int ORDER;
    public bool clicked = false;

    const float SPEED = 300;
    [SerializeField] private GameObject emptyObject;

    public RectTransform rectTransform;

    private void Start() { 
        rectTransform = GetComponent<RectTransform>();
    }
    public void ClickPerson() {
        if (clicked != true) {
            clicked = true;
            transform.parent.transform.GetComponent<GridLayoutGroup>().enabled = false;
            transform.GetComponent<EventTrigger>().enabled = false;

            Column currentColumn = GameController.Instance.GetCurrentColumn(ORDER);
            List<Path> path = currentColumn.Search();
            Debug.Log(path[path.Count - 1]);
            emptyObject.transform.parent = transform.parent;
            StartCoroutine(Move(path));
        }
    }
    IEnumerator Move(List<Path> path) {
        Vector2 nextPosition;
        for (int i = 0; i < path.Count; i++) {
            Path nextPath = i + 1 < path.Count ? path[i + 1] : null;
            transform.parent = path[i].GetParent(nextPath).transform;
            nextPosition = path[i].GetPosition(nextPath);

            //  Vector2 delta = nextPosition - rectTransform.anchoredPosition;
            //   int move = 0;
            //  for(int j=0; j<move; j++) {

            while (rectTransform.anchoredPosition != nextPosition) {
                //while (Vector2.Distance(rectTransform.anchoredPosition, nextPosition) > 0.1f){
                //rectTransform.anchoredPosition += delta;
                rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, nextPosition, SPEED * Time.deltaTime);
                yield return null;
                //}
            }
        }
    }
}
