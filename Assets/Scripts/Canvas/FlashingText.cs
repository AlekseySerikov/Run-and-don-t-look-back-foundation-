using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingText : MonoBehaviour
{

	private Text txt;
	//Скрипт для отображения мигающего текста в канвасе


	void Start()
	{
		txt = GetComponent<Text>();
	}


	void Update()
	{
		txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, Mathf.PingPong(Time.time / 2.5f, 1.0f));
        if (Input.GetMouseButtonDown(0)) 
        {
			Destroy(gameObject);
        }
	}
}

