using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timeScript : MonoBehaviour
{
    public Text counterText;
    public bool timeCounter = true;
    public float seconds, minutes;

    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>() as Text;
    }

	// Update is called once per frame
	void Update()
	{
		if (timeCounter)
		{
			seconds = (int)(Time.timeSinceLevelLoad % 60f);
			counterText.text = "Seconds" + ":" + seconds.ToString("00");
		}
	}

	public void endGame()// se llama al acabar la partida 
	{
		timeCounter = false;
		counterText.color = Color.yellow;
	}
}
