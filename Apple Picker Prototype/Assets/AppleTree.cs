using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    public static AppleTree S;
    // Яблочко
    public GameObject applePrefab;

    // Скорость движения дерева
    public float speed = 10f;

    // Расстояние на котором дерево поворачивает
    public float leftAndRitghtEdge = 18f;

    // Шанс с которым дерево поменяет направление
    public float chanceToChangeDirections = 0.1f;

    // Как часто падают яблоки
    public float secondsBetweenAppleDrops = 1f;

    // Скорость с которой дерево ускоряется
    public float distTreeSpeedUp = 1f;
    public float valTreeSpeedUp = 3f;

	// Use this for initialization
	void Start () {
        // Выбрасывание яблок каждую секунду	
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
        InvokeRepeating("SpeedUp", 2f, distTreeSpeedUp);
	}

    void DropApple() {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = this.transform.position;
    }

    void SpeedUp() {
        if (speed < 0) speed -= valTreeSpeedUp;
        if (speed > 0) speed += valTreeSpeedUp;
    }

    // Update is called once per frame
    void Update() {
        // Движение
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // Смена движения
        if (pos.x < -leftAndRitghtEdge) {
            speed = Mathf.Abs(speed);
        } else
        if (pos.x > leftAndRitghtEdge) {
            speed = -Mathf.Abs(speed);
        }   
	}

    void FixedUpdate() {
        // Смена направления рандомно
        if(Random.value < chanceToChangeDirections) {
            speed *= -1;
        }
    }
}
