using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private List<GameObject> rowLineList = new List<GameObject>();

    void Start(){
        gameObject.SetActive(true);
        for(int i = 0; i<rowLineList.Count; i++) {
            rowLineList[i].SetActive(false);
        }
        if (rowLineList.Count != 0) {
            for (int i = 0; i < 4; i++) {
                int random = Random.Range(0, 8);
                rowLineList[random].SetActive(true);
            }
        }
    }

}
