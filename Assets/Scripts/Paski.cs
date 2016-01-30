using UnityEngine;
using System.Collections;

public class Paski : MonoBehaviour 
    {   public float maxTime = 180;
        private float currentTime = 180;
        private float maxSpell =100;
        private float currentSpell=100;
        private float barWidth;
        private float barHeight;
        public Color timeColor;
        public Color stabilityColor;
    void Awake()
    {
        barHeight = Screen.height * 0.02f;
        barWidth = barHeight * 10.0f;

    }

	void Update ()
    {
        currentTime = maxTime - Time.time;
	}
}
