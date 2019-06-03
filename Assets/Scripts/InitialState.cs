using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class InitialState : MonoBehaviour {
    public string urlSource = "https://api.unibet.com/game-library-rest-api/getGamesByMarketAndDevice.json?categories=casino,softgames&clientId=casinoapp&jurisdiction=RO&locale=ro_RO&currency=RON&brand=unibet&deviceGroup=mobilephone";
	// Use this for initialization
	void Start () {
        StateManager.Instance.casinoBank = 1001;
        StartCoroutine(GetText());
        
    }
	
	// Update is called once per frame
	void Update () {
	}
        IEnumerator GetText()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(urlSource))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                JSONObject json = new JSONObject(www.downloadHandler.text);
                Debug.Log(json);
                StateManager.Instance.gameJSON = json;
                Debug.Log(StateManager.Instance.gameJSON["games"][0]["backgroundImageUrl"]);
                StateManager.Instance.loadAds();
            }
        }
    }
}
