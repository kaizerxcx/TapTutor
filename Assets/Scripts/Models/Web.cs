using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using RestClient.Core.Models;

public class Web : MonoBehaviour
{
    private const string defaultContentType = "application/json";

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // http://localhost/TapTutor/registerUser.php
    //http://52.237.120.241/TapTutor/registerUser.php
    public IEnumerator registerUser(string firstname, string middlename, string lastname, int age, string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("firstname", firstname);
        form.AddField("middlename", middlename);
        form.AddField("lastname", lastname);
        form.AddField("age", age);
        form.AddField("username", username);
        form.AddField("password", password);
        using (UnityWebRequest www = UnityWebRequest.Post("http://52.237.120.241/TapTutor/registerUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator login(string username, string password, System.Action<Response> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        using (UnityWebRequest www = UnityWebRequest.Post("http://52.237.120.241/TapTutor/login.php", form))
        {
          /* www.uploadHandler.contentType = defaultContentType;
           www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));*/

            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                callback(new Response
                {
                    StatusCode = www.responseCode,
                    Error = www.error
                });
            }
            if (www.isDone)
            {
                string data = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                callback(new Response
                {
                    StatusCode = www.responseCode,
                    Error = www.error,
                    Data = data
                });
            }
        }
    }

    public IEnumerator setShapePoints(int child_id, int points)
    {
        WWWForm form = new WWWForm();
        form.AddField("child_id", child_id);
        form.AddField("points", points);
        using (UnityWebRequest www = UnityWebRequest.Post("http://52.237.120.241/TapTutor/setShapePoints.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator getShapePoints(int child_id, System.Action<Response> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("child_id", child_id);
        using (UnityWebRequest www = UnityWebRequest.Post("http://52.237.120.241/TapTutor/getShapePoints.php", form))
        {
            /* www.uploadHandler.contentType = defaultContentType;
             www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));*/

            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                callback(new Response
                {
                    StatusCode = www.responseCode,
                    Error = www.error
                });
            }
            if (www.isDone)
            {
                string data = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                callback(new Response
                {
                    StatusCode = www.responseCode,
                    Error = www.error,
                    Data = data
                });
            }
        }
    }

    public IEnumerator setNumberPoints(int child_id, int points)
    {
        WWWForm form = new WWWForm();
        form.AddField("child_id", child_id);
        form.AddField("points", points);
        using (UnityWebRequest www = UnityWebRequest.Post("http://52.237.120.241/TapTutor/setNumberPoints.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator getNumberPoints(int child_id, System.Action<Response> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("child_id", child_id);
        using (UnityWebRequest www = UnityWebRequest.Post("http://52.237.120.241/TapTutor/getNumberPoints.php", form))
        {
            /* www.uploadHandler.contentType = defaultContentType;
             www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));*/

            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                callback(new Response
                {
                    StatusCode = www.responseCode,
                    Error = www.error
                });
            }
            if (www.isDone)
            {
                string data = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                callback(new Response
                {
                    StatusCode = www.responseCode,
                    Error = www.error,
                    Data = data
                });
            }
        }
    }


    public IEnumerator setLetterPoints(int child_id, int points)
    {
        WWWForm form = new WWWForm();
        form.AddField("child_id", child_id);
        form.AddField("points", points);
        using (UnityWebRequest www = UnityWebRequest.Post("http://52.237.120.241/TapTutor/setLetterPoints.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator getLetterPoints(int child_id, System.Action<Response> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("child_id", child_id);
        using (UnityWebRequest www = UnityWebRequest.Post("http://52.237.120.241/TapTutor/getLetterPoints.php", form))
        {
            /* www.uploadHandler.contentType = defaultContentType;
             www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));*/

            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                callback(new Response
                {
                    StatusCode = www.responseCode,
                    Error = www.error
                });
            }
            if (www.isDone)
            {
                string data = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                callback(new Response
                {
                    StatusCode = www.responseCode,
                    Error = www.error,
                    Data = data
                });
            }
        }
    }

    public IEnumerator getUserInfo(int child_id, System.Action<Response> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("child_id", child_id);
        using (UnityWebRequest www = UnityWebRequest.Post("http://52.237.120.241/TapTutor/getUserInfo.php", form))
        {
            /* www.uploadHandler.contentType = defaultContentType;
             www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));*/

            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                callback(new Response
                {
                    StatusCode = www.responseCode,
                    Error = www.error
                });
            }
            if (www.isDone)
            {
                string data = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                callback(new Response
                {
                    StatusCode = www.responseCode,
                    Error = www.error,
                    Data = data
                });
            }
        }
    }

    public IEnumerator editProfile(string firstname, string middlename, string lastname, int age, string username, string password,int child_id, System.Action<Response> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("firstname", firstname);
        form.AddField("middlename", middlename);
        form.AddField("lastname", lastname);
        form.AddField("age", age);
        form.AddField("username", username);
        form.AddField("password", password);
        form.AddField("child_id", child_id);
        using (UnityWebRequest www = UnityWebRequest.Post("http://52.237.120.241/TapTutor/editProfile.php", form))
        {
            /* www.uploadHandler.contentType = defaultContentType;
             www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));*/

            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                callback(new Response
                {
                    StatusCode = www.responseCode,
                    Error = www.error
                });
            }
            if (www.isDone)
            {
                string data = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                callback(new Response
                {
                    StatusCode = www.responseCode,
                    Error = www.error,
                    Data = data
                });
            }
        }
    }

    public IEnumerator getLeaderboard(System.Action<Response> callback)
    {
        
        using (UnityWebRequest www = UnityWebRequest.Get("http://52.237.120.241/TapTutor/getLeaderboard.php"))
        {
            /* www.uploadHandler.contentType = defaultContentType;
             www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));*/

            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                callback(new Response
                {
                    StatusCode = www.responseCode,
                    Error = www.error
                });
            }
            if (www.isDone)
            {
                string data = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                callback(new Response
                {
                    StatusCode = www.responseCode,
                    Error = www.error,
                    Data = data
                });
            }
        }
    }

    public IEnumerator setColorPoints(int child_id, int points)
    {
        WWWForm form = new WWWForm();
        form.AddField("child_id", child_id);
        form.AddField("points", points);
        using (UnityWebRequest www = UnityWebRequest.Post("http://52.237.120.241/TapTutor/setColorPoints.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator getColorPoints(int child_id, System.Action<Response> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("child_id", child_id);
        using (UnityWebRequest www = UnityWebRequest.Post("http://52.237.120.241/TapTutor/getColorPoints.php", form))
        {
            /* www.uploadHandler.contentType = defaultContentType;
             www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));*/

            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                callback(new Response
                {
                    StatusCode = www.responseCode,
                    Error = www.error
                });
            }
            if (www.isDone)
            {
                string data = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                callback(new Response
                {
                    StatusCode = www.responseCode,
                    Error = www.error,
                    Data = data
                });
            }
        }
    }

    public IEnumerator deleteInfo(int child_id)
    {
        WWWForm form = new WWWForm();
        form.AddField("child_id", child_id);
        using (UnityWebRequest www = UnityWebRequest.Post("http://52.237.120.241/TapTutor/deleteInfo.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

}
