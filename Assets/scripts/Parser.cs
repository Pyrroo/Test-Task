using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;
public class TimeFromServer : MonoBehaviour
{
    private static string timeServerUrl = "https://yandex.com/time/sync.json";

    public static async Task ParseTime()
    {

        using (HttpClient client = new HttpClient())
        {// Отправка GET-запроса
            HttpResponseMessage response = await client.GetAsync(timeServerUrl);

            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();

            JObject json = JObject.Parse(jsonResponse);

            long unixTimeMilliseconds = (long)json["time"];

            App_Controller.Current_DateTime = DateTimeOffset.FromUnixTimeMilliseconds(unixTimeMilliseconds).DateTime;
            
        }
    }
}
