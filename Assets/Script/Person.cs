using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Person : MonoBehaviour {
    public int ORDER;
    public bool clicked = false;
   
    private Vector2 firstPosition;
    const float SPEED = 300;
    string result;

    [SerializeField] private GameObject personObject;
    [SerializeField] private GameObject emptyObject;
    [SerializeField] private GameObject emptyObjectParent;

    private RectTransform rectTransform;
    
    public void Reset(){
        clicked = false;
        transform.SetParent(personObject.transform);
        emptyObject.transform.SetParent(emptyObjectParent.transform);
        transform.SetSiblingIndex(ORDER);
        transform.parent.transform.GetComponent<GridLayoutGroup>().enabled = true;
        transform.GetComponent<EventTrigger>().enabled = true;
        rectTransform.position = new Vector2(firstPosition.x, firstPosition.y);
    }
    private void Start() { 
        rectTransform = GetComponent<RectTransform>();
        firstPosition = new Vector2(rectTransform.position.x, rectTransform.position.y);
    }
    public string getResult(){
        return result;
    }
    public void ClickPerson() {
        if (clicked != true) {
            clicked = true;
            transform.parent.transform.GetComponent<GridLayoutGroup>().enabled = false;
            transform.GetComponent<EventTrigger>().enabled = false;

            //Route Search
            Column currentColumn = GameController.Instance.GetCurrentColumn(ORDER);
            List<Path> path = currentColumn.Search();

            //Debug.Log("######Result: " + path[path.Count - 1]);
            result = path[path.Count - 1].name;

            emptyObject.transform.SetParent(transform.parent);
            StartCoroutine(Move(path));
        }
    }
    IEnumerator Move(List<Path> path) {
        Path nextPath;
        Vector2 nextPosition;

        for (int i = 0; i < path.Count; i++) {
            //Get nextPath
            nextPath = i + 1 < path.Count ? path[i + 1] : null;

            //Change standard object
            transform.SetParent(path[i].GetParent(nextPath).transform);

            //Get nextPath's position
            nextPosition = path[i].GetPosition(nextPath);

            //Go to the nextPath position
            while (rectTransform.anchoredPosition != nextPosition) {
                rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, nextPosition, SPEED * Time.deltaTime);
                yield return null;
            }
        }
    }
}
