using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public Player player;
    public InputField textEntryField;
    public Text logText;
    public Text currentText;

    [TextArea]
    public string introText;
    
    public Action[] actions;
    // Start is called before the first frame update
    void Start()
    {
        logText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayLocation(){
        string description = player.currentLocation.description + "\n";
        description += player.currentLocation.GetConnectionsText();
        description += player.currentLocation.getItemsText();
        currentText.text = description;

    }

    public void TextEntered(){
        LogCurrentText();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
        textEntryField.ActivateInputField();

    }

    void LogCurrentText(){
        logText.text += "\n\n";
        logText.text += currentText.text;

        logText.text += "\n\n";
        logText.text += "<color=#aaccaaff>" + textEntryField.text + "</color>";
    }

    void ProcessInput(string input){
        input = input.ToLower();
        Debug.Log(input);
        char[] delimiter = { ' ' };
        string[] separatedWords = input.Split(delimiter);

        foreach(Action action in actions){
            if(separatedWords[0] == action.keyword.ToLower()){
                Debug.Log("Matched keyword: " + action.keyword);
                if(separatedWords.Length > 1){
                    action.RespondToInput(this, separatedWords[1]);
                    return;
                }
                else{
                    action.RespondToInput(this, "");
                    return;
                }
            }
        }
        currentText.text = "Nothing happens! (having trouble? type 'help')";
    }
}
