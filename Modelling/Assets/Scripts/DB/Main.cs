using UnityEngine;

public class Main : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void OnAppStart()
    {
    
     //    var user2 = new User("Peter", 61);
     //    DatabaseHandler.PostUser(user2, "3", () =>{
     //    	DatabaseHandler.GetUser("1", user =>{
     //    		Debug.Log($"{user.name} {user.age}");
    	// 	});
    	// });

        // DatabaseHandler.GetUsers(users =>{
        	// foreach (var user in users){
        	// 	Debug.Log($"{user.Value.name} {user.Value.age}");
        	// }
    	// });


        DatabaseHandler.GetCoordinates(values =>{

        });

        

    }
}
