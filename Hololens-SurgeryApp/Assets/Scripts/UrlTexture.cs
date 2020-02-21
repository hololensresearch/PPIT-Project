using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
 
public class UrlTexture : MonoBehaviour {
    private string url;

    public void ChangeTexture(int option){
        StartCoroutine(GetTexture(option));
    }
 
    IEnumerator GetTexture(int option) {
        
        if (option == 1)
        {
            url = "https://upload.wikimedia.org/wikipedia/commons/4/42/X-ray_of_a_normal_hip.jpg";
            Debug.Log(url);
        }
        else if (option == 2)
        {
            url = "https://prod-images-static.radiopaedia.org/images/28500021/a968d647cea91b82e7d5c0ede3929a_jumbo.jpeg";
            Debug.Log(url);
        }
        else {
            url = "https://tr4.cbsistatic.com/hub/i/2016/05/26/7e933f3d-d740-4ffb-8a73-87072503807e/error-cascade.jpg";
            Debug.Log("Invalid");
        }
    

        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            GameObject changeImage = GameObject.Find("ChangeImage");
		    changeImage.GetComponent<RawImage>().texture = myTexture;
        }
    }
}