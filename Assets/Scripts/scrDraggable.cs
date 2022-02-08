using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class scrDraggable : MonoBehaviour {
    [HideInInspector]
    public bool matched = false;
    [HideInInspector]
    public bool pointTaken = false; //puanı sayılmış mı sayılmamış mı
    private float mx, my; // tıklanılan yerden tutmak için
    [HideInInspector]
    public Vector3 startingPos; // dönülecek pozisyon

    private scrController controller;



    private void Awake()
    {
        startingPos = transform.position;
        controller = GameObject.FindWithTag("GameController").GetComponent<scrController>();
        gameObject.tag = "draggable";
        transform.Translate(new Vector3(0, 0, -2.5f)); // tıklama bugı fix
        GetComponent<SpriteRenderer>().sortingOrder = 1; // staticlerden üste çıkarma
    }

    private void OnMouseDown()
    {
        if(controller.selectedObject.tag == "GameController")
        {

            controller.selectedObject = this.transform.gameObject;
            GetComponent<SpriteRenderer>().sortingOrder += 1; // seçili obje daha üste çıksın

        }

        mx = transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        my = transform.position.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
    }


    public void OnMouseUp()
    {
        controller.selectedObject = controller.transform.gameObject;
        GetComponent<SpriteRenderer>().sortingOrder -= 1;

    }

    public void Update()
    {
        if(controller.selectedObject == this.transform.gameObject && !matched)
        {
            Vector3 relativePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(relativePos.x +mx, relativePos.y +my);

        }
    }


    public void OnCollisionStay2D(Collision2D col)
    {

        if(!matched && gameObject.name + "_"  == col.transform.name) // eğer ID ler uyuşuyorsa
        {
            if(Vector2.Distance(transform.position, col.transform.position) < 1 && controller.selectedObject.tag == "GameController")
            {
                matched = true;
                transform.position = col.transform.position;
                GetComponent<PolygonCollider2D>().enabled = false;
                StartCoroutine(controller.CheckWinCondition()); // Eğer kazanmışsak kontrol edelim
            }
        }


    
    }





}
