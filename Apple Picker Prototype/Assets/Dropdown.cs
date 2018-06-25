using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropdown : MonoBehaviour {

    Text text;
    Dropdown dropdown;
    List<string> controls;

    void Awake() {
        text = GameObject.Find("DropdownText").GetComponent<Text>();
        controls = new List<string>(Control.GetNames(typeof(Control)));
        if (PlayerPrefs.HasKey("Control")) {
            int ind = controls.IndexOf(PlayerPrefs.GetString("Control"));
            Basket.control = (Control)ind;
        } else {
            PlayerPrefs.SetString("Control","None");
        }
    }

    //void PopulateOptions() {
    //    dropdown = this.GetComponent<Dropdown>();
    //    foreach (string option in controls) {
    //        //this.GetComponent<Dropdown>().

    //    }
    //}
	
	// Update is called once per frame
	void Update () {
        text.text = Basket.control.ToString();
	}

    public void OnValueChanged(int ind) {
        string control = controls[ind];
        PlayerPrefs.SetString("Control", control);
        Basket.control = (Control)ind;
    }
}
