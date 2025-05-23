using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemWaypointController : MonoBehaviour
{
	public TMPro.TextMeshProUGUI mItemWaypointText; // Referencia al texto items waypoints del canvas
    public Slider mItemWaypointSlider; // Referencia al slider 
    public int mItemWaypointToCollect; // Referencia a la cantidad de items waypoints
    public int mItemWaypointCollected; // Referencia a la cantidad de items waypoints recolectados

	private void Start() 
	{
		// Seteo de valores iniciales del slider
		mItemWaypointSlider.maxValue = mItemWaypointToCollect; // Maximo valor permitido
		mItemWaypointSlider.value = mItemWaypointCollected; // Valor actual
		mItemWaypointSlider.interactable = false;

		ItemWaypointTextCounter();
	}

	// Metodo contador para cantidad items waypoints recolectados en slider
	public void ItemWaypointCounter()
	{
		mItemWaypointCollected++; // Incremento del contador
		mItemWaypointCollected = Mathf.Clamp(mItemWaypointCollected, 0, mItemWaypointToCollect); // No excede limite recolectado
		mItemWaypointSlider.value = mItemWaypointCollected; // Actualiza slider
	}

	// Metodo para actualizar cantidad de items waypoints recolectados en texto
	public void ItemWaypointTextCounter()
	{
		mItemWaypointText.text = mItemWaypointCollected.ToString() + "/" + mItemWaypointToCollect.ToString(); // Actualiza el texto
	}

	public int ItemWaypointCollected
	{
		get { return mItemWaypointCollected; }
		set { mItemWaypointCollected = value; }
	}

	// Metodo trigger para recolectar items waypoints
	/*private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "ItemWaypoint")
		{
			ItemWaypointCounter(); // Llamado al metodo contador
			LevelData.WaypointsCollectedInLevel = mItemWaypointCollected; // Actualiza los datos en LevelData
			Debug.Log("Waypoints recolectados: " + LevelData.WaypointsCollectedInLevel); // Verifica el valor
			ItemWaypointTextCounter();
			Destroy(other.gameObject);
			Debug.Log("Waypoint collected"); // Mensaje de depuración
		}
	}*/
}
