using System.Collections.Generic;
using FullSerializer;
using Proyecto26;
using UnityEngine; //added this to use Debug.Log
using SimpleJSON;

public static class DatabaseHandler
{
    private const string projectId = "fir-acf21";
    private static readonly string databaseURL = $"https://fir-acf21.firebaseio.com";
    private static string temperatureURL = $"https://api.openweathermap.org/data/2.5/weather?lat=35&lon=139";

    public static float targetX = 0;
    public static float targetY = 0;
    public static float targetZ = 0;

    private static fsSerializer serializer = new fsSerializer();

    public delegate void PostUserCallback();
    public delegate void GetUserCallback(User user);
    public delegate void GetUsersCallback(Dictionary<string, User> users);

    public static void PostUser(User user, string userId, PostUserCallback callback)
    {
    	RestClient.Put<User>($"{databaseURL}/users/{userId}.json", user).Then(response =>  {callback();});
    }

    public static void GetUser(string userId, GetUserCallback callback)
    {
    	RestClient.Get<User>($"{databaseURL}/users/{userId}.json").Then(user => {callback(user);});
    }

    public static void GetUsers(GetUsersCallback callback)
    {
        
    	RestClient.Get($"{databaseURL}/users.json").Then(response => {
    		var responseJson = response.Text;
            Debug.Log("Response: " + responseJson);
    		//Using FullSerializer library to serialize a Dictionary datatype in this case
    		var data = fsJsonParser.Parse(responseJson);
    		object deserialized = null;
    		serializer.TryDeserialize(data, typeof(Dictionary<string, User>), ref deserialized);

    		var users = deserialized as Dictionary<string, User>;
    		callback(users);
    		});
    }

    public static void GetCoordinates(GetUsersCallback callback)
    {
        
        RestClient.Get($"{databaseURL}/users/target.json").Then(response => {
            var responseJson = response.Text;
            Debug.Log("Response" + responseJson);
            var N = JSON.Parse(responseJson);
            targetX = N["x"].AsFloat;
            targetY = N["y"].AsFloat;
            targetZ = N["z"].AsFloat;
            // Debug.Log("X is: " + targetX );
            //Using FullSerializer library to serialize a Dictionary datatype in this case
            var data = fsJsonParser.Parse(responseJson);
            object deserialized = null;
            serializer.TryDeserialize(data, typeof(Dictionary<string, User>), ref deserialized);

            var users = deserialized as Dictionary<string, User>;
            callback(users);

            });      
    }
}
