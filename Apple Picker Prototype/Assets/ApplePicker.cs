using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour {

    /*
        -Сделать повышающийся со временем уровень сложности
        Увеличивается скорость дерева и корзинки
        -Сделать управление с помощью геймпада
        -Сделать режим с показанием кпд
        -Яблоки отскакивают и исчезают через несколько секунд
        -Сделать гуи подходящим к экрану
    */
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;


	// Use this for initialization
	void Start () {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++) {
            GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + basketSpacingY * i;
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }	
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void AppleDestroyed() {
        // Уничтожаем все падающие яблоки
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray) {
            Destroy(tGO);
        }
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        // Перезагружаем игру
        if(basketList.Count == 0) {
            Application.LoadLevel("_Scene_0");
        }
    }
}
