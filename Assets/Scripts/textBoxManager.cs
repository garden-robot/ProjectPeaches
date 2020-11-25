using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textBoxManager : MonoBehaviour
{
    public GameObject textBox; // textbox image
    public Text theText; // the actual text

    public walking player; // the player moving


    public TextAsset textFile; // text file (currently not in use because I don't have one that runs in unity)
    public string[] textLines; // the line in the textfiles, which aren't in use

    public int currentLine; // line its on
    public int endAtLine; // last line


    public bool isActive; // is the textbox active
    public bool stopPlayerMovement; 

    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<walking>();

        if (textFile != null) // if there is a text file to look at
        {

            textLines = (textFile.text.Split('\n')); // seperate them by \n, which means by space enter
        }

        if(endAtLine == 0) // if you just started talking to the npc
        {

            endAtLine = textLines.Length - 1; // start at line one (remember unity starts at 0)
        }

        if (isActive) // if the textbox is active
        {
            EnableTextBox();
        }else
        {
            DisableTextBox();
        }

    }

    void Update()
    {

        if (!isActive) // if there is no text box
        {
            return; // dont run code
        }


        theText.text = textLines[currentLine]; // giving the text box in unity actual text from a text file (which again, I'm not using)

        if (Input.GetKeyDown(KeyCode.Return)) // if you press space
        {
            currentLine += 1; // goes to next line
        }

        if(currentLine > endAtLine) // if you're at the end
        {
            DisableTextBox(); // disable the text box

        }
    }

    public void EnableTextBox() // function to enable text box
    {
        textBox.SetActive(true);

        if (stopPlayerMovement)
        {
            player.canMove = false;
        }

    }

    public void DisableTextBox() // function to disable text box
    {
        textBox.SetActive(false);

        player.canMove = true; 

    }
}
