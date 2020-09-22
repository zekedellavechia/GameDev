﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{




    void Start()
    {
        //this print works in the Console of unity
        ConsoleBackgroundMessages();
        ShowMainMenu("Hello Ben");
        
    }

    private static void ConsoleBackgroundMessages()
    {
        print("Game Initiated");
        print("Welcome!");
        print("Game is running up.");
    }

    private static void ShowMainMenu(string greeting)
    {
        string nombre = "Benito";

        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Press 1 for Level Easy (Colours)");
        Terminal.WriteLine("Press 2 for Level Medium (Games)");
        Terminal.WriteLine("Press 3 for Lever Hard (Random)");
        Terminal.WriteLine("Choose your destiny " + nombre + ": ");
    }

    void OnUserInput(string input)
    {
        if (input == "1")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("You choose Level 1");
            print("You choose level 1");
        }
        else if (input == "2")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("You choose Level 2");
            print("You choose level 2");
        }
        else if (input == "3")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("You choose Level 3");
            print("You choose level 3");
        }
        else if (input =="menu")
        {
            Terminal.ClearScreen();
            ShowMainMenu("Welcome back Ben");
        }
        else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Invalid command, please choose a Level between 1 and 3");
            print("Invalid command");
        }

    }
    //variables
    //variables are like boxes, the way to define is like "var lives = 3;" or reemplace var with the 



    //if (some expression evaluate to true)
    //{ execute this}
    //else if (some other expression is true)
    //else {execute this code only]


}
