using UnityEngine;
using System.Collections;

public class Paski : MonoBehaviour 
    {   public float maxTime = 180;
        private float currentTime = 180;
        private float maxSpell =100;
        private float currentSpell=100;
        private float barWidth;
        private float barHeight;
        public Texture2D timeTexture;
        public Texture2D spellTexture;
    void Awake()
    {
        barHeight = Screen.height * 0.02f;
        barWidth = barHeight * 10.0f;

    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect( 10,
                                  10,
                                 currentTime * barWidth / maxTime,
                                 barHeight),
                        timeTexture);
        GUI.DrawTexture(new Rect( 10,
                                  20,
                                 currentSpell * barWidth / maxSpell,
                                 barHeight),
                        spellTexture);
    }
	// Update is called once per frame
	void Update ()
    {
        currentTime = maxTime - Time.time;
	}
}
