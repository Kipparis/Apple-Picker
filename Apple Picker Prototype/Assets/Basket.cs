using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePos2D = Input.mousePosition;

        // Координата z камеры говорит как далеко протолкнуть мыш
        mousePos2D.z = -Camera.main.transform.position.z;

        // Конвертируем
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Изменяем х координату корзинки
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }

    void OnCollisionEnter(Collision coll) {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple") {
            Destroy(collidedWith);
        }
    }
}
