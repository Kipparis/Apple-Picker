using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
    static public int score = 10;

    void Awake() {
        // Если высший счёт уже существует, считываем его
        if (PlayerPrefs.HasKey("ApplePickerHighScore")) {
            score = PlayerPrefs.GetInt("ApplePickerHighScore");
        }
        PlayerPrefs.SetInt("ApplePickerHighScore", score);

        // Задаём позицию
        Vector3 pos = new Vector3(Screen.width * 3 / 4, Screen.height / 20);
        this.transform.position = pos; 
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;
        // Обновляем данные на компе если нужно
        if (score > PlayerPrefs.GetInt("ApplePickerHighScore")) {
            PlayerPrefs.SetInt("ApplePickerHighScore", score);  
        }
	}
}
