using UnityEngine;
using System.Collections;

public class ItemHandler : MonoBehaviour {

    public float AutoCoinGetDelay = 2.0f;

    private GameObject tmpGameController;
    private int nCoinValue;

	// Use this for initialization
	void Start () {
        tmpGameController = GameObject.Find("GameController");

        StartCoroutine("AutoItemGet");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        //Vector3 mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            ItemGet();
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.name == "AutoGetZone")
        {
            ItemGet();
        }
    }

    protected void CoinValueSetting(int nValue)
    {
        nCoinValue = nValue;
    }

    protected void ItemGet()
    {
        tmpGameController.SendMessage("CoinValueSetting", nCoinValue);
        tmpGameController.SendMessage("CoinHitValue", Camera.main.WorldToScreenPoint(transform.position));

        Destroy(gameObject);
    }

    IEnumerator AutoItemGet()
    {
        yield return new WaitForSeconds(AutoCoinGetDelay);

        ItemGet();
    }
}
