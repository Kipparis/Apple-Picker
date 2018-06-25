using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {
    public static float bottomY = -20f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < bottomY) {
            Destroy(this.gameObject);
            // Находим ссылку на ЭплПикер компонент
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // Вызываем оттуда функцию
            apScript.AppleDestroyed();
        }
    }

    public void Destroyed(float time = 0f) {
        Invoke("Destroy", time);
    }

    public void Destroy() {
        Destroy(this.gameObject);
    }
}
