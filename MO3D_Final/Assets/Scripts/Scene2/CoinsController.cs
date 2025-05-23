using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsController : MonoBehaviour
{
	public TMPro.TextMeshProUGUI mItemCoinsText; // Referencia al texto items coins del canvas
	public Slider mItemCoinsSlider; // Referencia al slider 
	public int mItemCoinsToCollect; // Referencia a la cantidad de items coins
	public int mItemCoinsCollected; // Referencia a la cantidad de items coins recolectados

	private void Start()
	{
		// Seteo de valores iniciales del slider
		mItemCoinsSlider.maxValue = mItemCoinsToCollect; // Maximo valor permitido
		mItemCoinsSlider.value = mItemCoinsCollected; // Valor actual
		mItemCoinsSlider.interactable = false;

		ItemCoinsTextCounter();
	}

	// Metodo contador para cantidad items coins recolectados en slider
	public void ItemCoinsCounter()
	{
		mItemCoinsCollected++; // Incremento del contador
		mItemCoinsCollected = Mathf.Clamp(mItemCoinsCollected, 0, mItemCoinsToCollect); // No excede limite recolectado
		mItemCoinsSlider.value = mItemCoinsCollected; // Actualiza slider
	}

	// Metodo para actualizar cantidad de items coins recolectados en texto
	public void ItemCoinsTextCounter()
	{
		mItemCoinsText.text = mItemCoinsCollected.ToString() + "/" + mItemCoinsToCollect.ToString(); // Actualiza el texto
	}

	// Metodo trigger para recolectar items coins
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Coins")
		{
			ItemCoinsCounter(); // Llamado al metodo contador
			MainMenu.Instance.AddCoin(1); // Llamado al metodo de suma de monedas
			LevelData.CoinsCollectedInLevel = mItemCoinsCollected; // Actualiza los datos en LevelData
			ItemCoinsTextCounter(); // Llamado al texto para actualizar las monedas
		}
	}
}
