using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Paski : MonoBehaviour
    {
        public GameObject timeBar;
        public GameObject stabilityBar;
        public GameObject timeBarBg;
        public GameObject stabilityBarBg;
        public float barWidth;
        private float startTime;
        public float levelTime;

    void Start()
    {
        levelTime = 20;
        startTime = Time.time;
        barWidth = Screen.width * 0.2f;

        timeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(barWidth, 20);
        stabilityBar.GetComponent<RectTransform>().sizeDelta = new Vector2(barWidth, 20);
        timeBarBg.GetComponent<RectTransform>().sizeDelta = new Vector2(barWidth, 20);
        stabilityBarBg.GetComponent<RectTransform>().sizeDelta = new Vector2(barWidth, 20);
    }

	void Update ()
    {
        if (stabilityBar.GetComponent<RectTransform>().sizeDelta.x != GameObject.Find("GameController").GetComponent<Gra>().stability * barWidth / 100)
        {
            stabilityBar.GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("GameController").GetComponent<Gra>().stability * barWidth / 100, 20);
            GameObject.Find("stabilityPercent").GetComponent<Text>().text = GameObject.Find("GameController").GetComponent<Gra>().stability.ToString()+"%";
        }

        //Debug.Log(Time.time + " ; " + startTime + " ; "  + levelTime + " ; " + barWidth);
        timeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(barWidth - barWidth * (Time.fixedTime - startTime) / levelTime, 20);
        string tmp = !(String.IsNullOrEmpty((levelTime - Time.fixedTime - startTime).ToString()) || (levelTime - Time.fixedTime - startTime).ToString().Length < 4) ? (levelTime - Time.fixedTime - startTime).ToString().Substring(0,4) : (levelTime - Time.fixedTime - startTime).ToString();
        GameObject.Find("timeLeft").GetComponent<Text>().text = tmp + " s";
    }
}
