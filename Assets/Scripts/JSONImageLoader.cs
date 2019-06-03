using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class JSONImageLoader : MonoBehaviour {

void Start()
    {
        
    }

public void LoadTexture(string url) {
    StartCoroutine(SetTexture(url));
}

public IEnumerator SetTexture(string url)
    {
        url = url.Replace("\"", "");
        Debug.Log("Loading texture " + url);
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        using (WWW www = new WWW(url))
        {
            yield return www;
            www.LoadImageIntoTexture(tex);
            GetComponent<Renderer>().material.mainTexture = tex;
            Debug.Log("Set texture");
        }
    }
}