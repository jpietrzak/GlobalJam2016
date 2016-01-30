using UnityEngine;
using System.Collections;

public class Paski : MonoBehaviour
    {
        public Color timeColor;
        public Color stabilityColor;
    public GameObject timeBar;
    public GameObject stabilityBar;
    public GameObject timeBarBg;
    public GameObject stabilityBarBg;
    public float barWidth;
    
    void Awake()
    {
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
        }
	}
}
