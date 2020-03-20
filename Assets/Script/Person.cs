using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Person : MonoBehaviour
{
    Coroutine coroutine;

    private const string RIGHT = "Right";
    private const string LEFT = "Left";
    private const string WINNING = "Winning";
    private bool moveHorizontal = false;

    public void ClickPerson(){
        transform.parent.transform.GetComponent<GridLayoutGroup>().enabled = false;
        coroutine = StartCoroutine(MoveUnder());
    }
    private void OnTriggerEnter2D(Collider2D other) {
        StopCoroutine(coroutine);

        if (moveHorizontal) {
            moveHorizontal = false;
            coroutine = StartCoroutine(MoveUnder());
        }
        else if (other.gameObject.name == LEFT){ //왼쪽 Collider만나면 오른쪽으로 이동
            moveHorizontal = true;
            coroutine = StartCoroutine(MoveRight());
        }
        else if (other.gameObject.name == RIGHT){ //오른쪽 Collider만나면 왼쪽으로 이동
            moveHorizontal = true;
            coroutine = StartCoroutine(MoveLeft());
        }
        else if(other.gameObject.name == WINNING){
            StopCoroutine(coroutine);
        }
    }
    IEnumerator MoveUnder(){
        while (true){
            yield return new WaitForSeconds(Time.deltaTime);
            transform.position = new Vector2(transform.position.x, transform.position.y - 5f);
        }
    }
    IEnumerator MoveRight(){
        while (true){
            yield return new WaitForSeconds(Time.deltaTime);
            transform.position = new Vector2(transform.position.x + 5f, transform.position.y);
        }
    }
    IEnumerator MoveLeft(){
        while (true) {
            yield return new WaitForSeconds(Time.deltaTime);
             transform.position = new Vector2(transform.position.x - 5f, transform.position.y);
        }
    }
}
