using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;

    enum Screen { MainMenu, Password, Win}
    Screen currentScreen;

    void Start()
    {
        //this print works in the Console of unity
        ConsoleBackgroundMessages();
        ShowMainMenu("Hello Ben");

        
    }

    private void ConsoleBackgroundMessages()
    {
        print("Game Initiated");
        print("Welcome!");
        print("Game is running up.");
    }

    private void ShowMainMenu(string greeting)
    {
        string nombre = "Benito";
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Press 1 for Level Easy (Colours)");
        Terminal.WriteLine("Press 2 for Level Medium (Games)");
        Terminal.WriteLine("Press 3 for Lever Hard (Random)");
        Terminal.WriteLine("Choose your destiny " + nombre + ": ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            Terminal.ClearScreen();
            ShowMainMenu("Welcome back Ben");
        }
        else if (currentScreen == Screen.MainMenu)
        { 
        RunMainMenu(input);
        }
    }

    private void RunMainMenu(string input)
    {
        if (input == "1")
        {
            Terminal.ClearScreen();

            level = 1;
            Terminal.WriteLine("You choose Level 1");
            print("You choose level 1");
            StartGame();
        }
        else if (input == "2")
        {
            Terminal.ClearScreen();
            level = 2;
            Terminal.WriteLine("You choose Level 2");
            print("You choose level 2");
        }
        else if (input == "3")
        {
            Terminal.ClearScreen();
            level = 3;
            Terminal.WriteLine("You choose Level 3");
            print("You choose level 3");
        }

        else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Invalid command, please choose a Level between 1 and 3");
            print("Invalid command");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("Welcome to Level " + level);
        Terminal.WriteLine("Please type the password: ");
    }
    //variables
    //variables are like boxes, the way to define is like "var lives = 3;" or reemplace var with the 



    //if (some expression evaluate to true)
    //{ execute this}
    //else if (some other expression is true)
    //else {execute this code only]


}
