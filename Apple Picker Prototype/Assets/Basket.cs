using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public enum Control {
    mouse,
    gamepad
}

public class Basket : MonoBehaviour {
    public static Control control;

    public float speed;
    public Text scoreGT;
    public AppleTree appleTree;

    // Use this for initialization
    void Start () {
        // Находим ссылку на счётчик
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Извлекаем GUI компонет
        scoreGT = scoreGO.GetComponent<Text>();
        // Задаём стартовый счёт от 0
        scoreGT.text = "0";
        // Находим скрипт дерева
        appleTree = GameObject.Find("AppleTree").GetComponent<AppleTree>();
	}
	
	// Update is called once per frame
	void Update () {
        // Скорость корзинки такая же как у дерева
        speed = Mathf.Abs(appleTree.speed);
        // Если мы играем мышкой
        if(control == Control.mouse) {
            Vector3 mousePos2D = Input.mousePosition;

            // Координата z камеры говорит как далеко протолкнуть мыш
            mousePos2D.z = -Camera.main.transform.position.z;

            // Конвертируем
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

            // Изменяем х координату корзинки
            Vector3 pos = this.transform.position;
            pos.x = mousePos3D.x;
            this.transform.position = pos;
        } else {
            Vector3 pos = transform.position;
            // Если играем клавой или геймпадом
            if (Input.GetAxis("Horizontal") > 0) {
                // Двигаемся вправо
                pos.x += speed * Time.deltaTime;
            } else if (Input.GetAxis("Horizontal") < 0){
                // Двигаемся влево
                pos.x -= speed * Time.deltaTime;
            }
            transform.position = pos;
        }
        
    }

    void OnCollisionEnter(Collision coll) {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple") {
            Apple apple = collidedWith.GetComponent<Apple>();
            apple.Destroyed(1f);
            //Destroy(collidedWith);
        }

        // Переводим текст в число
        int score = int.Parse(scoreGT.text);
        // Добавляем очки за яблочки
        score += 1;
        // Конвертируем обратно в строчку и отображаем
        scoreGT.text = score.ToString();

        // Отслеживаем лучший результат
        if (score > HighScore.score) {
            HighScore.score = score;
        }
    }
}
