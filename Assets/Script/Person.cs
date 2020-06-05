using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Person : MonoBehaviour {
    public int ORDER;
    public bool clicked = false;
   
    const float SPEED = 150;
    string result;

    [SerializeField] private GameObject personObject;
    [SerializeField] private Transform personImage;
    [SerializeField] private Text personNameText;
    private RectTransform rectTransform;

    public void Reset(){
        clicked = false;

        transform.SetParent(personObject.transform);
        transform.SetSiblingIndex(ORDER);

        transform.parent.transform.GetComponent<HorizontalLayoutGroup>().enabled = true;
        transform.GetComponent<EventTrigger>().enabled = true;

        personImage.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
   
    void Awake(){
        rectTransform = GetComponent<RectTransform>();
        personImage.gameObject.SetActive(true);
    }

    void Update(){
        personImage.position = transform.position;
    }

    public string getResult(){
        return result;
    }
  
    public void FirstSetting(string name){ 
        personNameText.text = name;
        personImage.gameObject.SetActive(true);
    }

    public void ClickPerson() {
        if (clicked != true) {
            clicked = true;

            transform.parent.transform.GetComponent<HorizontalLayoutGroup>().enabled = false;
            transform.GetComponent<EventTrigger>().enabled = false;

            //Route Search
            Column currentColumn = GameController.Instance.GetCurrentColumn(ORDER);
            List<Path> path = currentColumn.Search();
            result = path[path.Count - 1].name;

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
        GameController.Instance.OpenResult(result);
    }
}
