using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
        if (stabilityBar.GetComponent<RectTransform>().sizeDelta.x != GameObject.FindGameObjectWithTag("GameController").GetComponent<Gra>().stability * barWidth / 100)
        {
            stabilityBar.GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.FindGameObjectWithTag("GameController").GetComponent<Gra>().stability * barWidth / 100, 20);
            GameObject.Find("stabilityPercent").GetComponent<Text>().text = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gra>().stability.ToString()+"%";
        }

        //Debug.Log(Time.time + " ; " + startTime + " ; "  + levelTime + " ; " + barWidth);
        timeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(barWidth - barWidth * (Time.fixedTime - startTime) / levelTime, 20);
        GameObject.Find("timeLeft").GetComponent<Text>().text = (levelTime - Time.fixedTime - startTime).ToString() + " s";
    }
}
