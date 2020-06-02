using System;

[Serializable]
public class User
{
    public string name;
    public int age;

    public User(string name, int age)
    {
    	this.name = name;
    	this.age = age;
    }
}
