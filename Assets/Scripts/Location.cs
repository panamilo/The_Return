using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string locationName;
    [TextArea]
    public string description;
    public Connection[] connections;
    public List<Item> items = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getItemsText(){
        if(items.Count==0)
            return "";
        string result = "You see: ";
        bool first=true;
        foreach(Item item in items){
            if(item.itemEnabled)
            {
                if(!first)
                    result += " and ";
                result += item.description;
                first = false;
            }
        }
        result += "\n";
        return result;
    }
    public string GetConnectionsText(){
        string result = "";
        foreach(Connection connection in connections){
            if(connection.connectionEnabled){
                result += connection.description + "\n";
            }
        }
        return result;
    }
    public Connection GetConnection(string connectionNoun){
        foreach(Connection connection in connections){
            if(connection.connectionName.ToLower() == connectionNoun.ToLower()){
                return connection;
            }
        }
        return null;
    }
    public bool HasItem(Item targetItem){
        foreach(Item item in items){
            if(item == targetItem && item.itemEnabled)
                return true;
        }
        return false;
    }
}
