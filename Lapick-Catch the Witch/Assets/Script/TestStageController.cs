using UnityEngine;
using System.Collections;

public class TestStageController : MonoBehaviour {

	public GameObject bg01;
	public GameObject bg02;
	public GameObject bg03;
	public GameObject bg04;
	public GameObject bg05;
	public GameObject bg06;
	public GameObject bg07;

	public float scrollSpeed;

	private float totalScrollSpeedBg01;
	private float totalScrollSpeedBg02;
	private float totalScrollSpeedBg03;
	private float totalScrollSpeedBg04;
	private float totalScrollSpeedBg05;
	private float totalScrollSpeedBg06;
	private float totalScrollSpeedBg07;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		totalScrollSpeedBg01 = scrollSpeed * Time.time;
		totalScrollSpeedBg02 = totalScrollSpeedBg01 * 0.7f;
		totalScrollSpeedBg03 = totalScrollSpeedBg02 * 0.7f;
		totalScrollSpeedBg04 = totalScrollSpeedBg03 * 0.7f;
		totalScrollSpeedBg05 = totalScrollSpeedBg04 * 0.7f;
		totalScrollSpeedBg06 = totalScrollSpeedBg05 * 0.7f;
		totalScrollSpeedBg07 = totalScrollSpeedBg06 * 0.7f;


		bg01.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(totalScrollSpeedBg01, 0);
		bg02.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(totalScrollSpeedBg02, 0);
		bg03.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(totalScrollSpeedBg03, 0);
		bg04.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(totalScrollSpeedBg04, 0);
		bg05.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(totalScrollSpeedBg05, 0);
		bg06.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(totalScrollSpeedBg06, 0);
		bg07.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(totalScrollSpeedBg07, 0);
	
	}
}
