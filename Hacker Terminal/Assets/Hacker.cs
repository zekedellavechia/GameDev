using UnityEngine;

public class Hacker : MonoBehaviour
{

    //GAME CONFIG
    const string menuHint = "Escribe menu para regresar!";
    string[] level1passwords = { "ren", "stimpy", "tronco"};
    string[] level2passwords = { "kenny", "stan", "kyle", "cartman", "randy", "butters" };
    string[] level3passwords = { "bart", "homero", "marge", "maggie", "apu", "nelson" };
    string[] level69passwords = { "galactico", "emmux vx", "el gran cono mayor" };


    int level;

    enum Screen { MainMenu, Password, Win}
    Screen currentScreen;
    string password;
    void Start()
    {
        //this print works in the Console of unity
        ShowMainMenu("Bienvenido Cono");


        
    }



    private void ShowMainMenu(string greeting)
    {
        //string nombre = "Benito";
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Tienes que advinar quien eres...");
        Terminal.WriteLine("Elige el nivel:");
        Terminal.WriteLine("Pon 1 para Nivel MTV");
        Terminal.WriteLine("Pon 2 para Nivel Nieve");
        Terminal.WriteLine("Pon 3 para Nivel Amarillo");
        //Terminal.WriteLine("Choose your destiny " + nombre + ": ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            Terminal.ClearScreen();
            ShowMainMenu("Bienvenido de vuelta Cono!");
        }
        else if (input == "quit" || input == "exit" || input == "salir" || input == "close" || input == "cerrar")
        {
            Terminal.WriteLine("Puedes cerrar la pestaña.");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }



    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" || input == "69");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }    

        else
        {
            Terminal.ClearScreen();
            currentScreen = Screen.MainMenu;
            Terminal.WriteLine("Comando invalido, por favor elige entre 1 y 3");
            print("Invalid command");
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Pon el Password (nombre del personaje) para ganar, pista: " + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1passwords[Random.Range(0, level1passwords.Length)];
                break;
            case 2:
                password = level2passwords[Random.Range(0, level2passwords.Length)];
                break;
            case 3:
                password = level3passwords[Random.Range(0, level3passwords.Length)];
                break;
            case 69:
                password = level69passwords[Random.Range(0, level69passwords.Length)];
                break;
            default:
                Debug.LogError("No level password");
                break;

        }
    }

    //variables
    //variables are like boxes, the way to define is like "var lives = 3;" or reemplace var with the 



    //if (some expression evaluate to true)
    //{ execute this}
    //else if (some other expression is true)
    //else {execute this code only]

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
           // Terminal.WriteLine("Mal Password, intenta nuevamente o pon menu para volver");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);

    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"
     /|_\|/_/|
    , ,--,-. .
   / ( O  O ) \
   |  (___)'  |
   |.   ,     |
  /  '-'\__,' |
Al final eras Stimpy, muy tonto. Fin.");
                break;
            case 2:
                Terminal.WriteLine(@"
        .
       -|-
        |
    .-'~~~`-.
  .'         `.
  |  R  I  P  |
  |           |
  |           |
\\|           |//
Eras Kenny de South Park. Fin.");
            break;
            case 3:
                Terminal.WriteLine(@"

 |\/\/\/|  
 |      |  
 |      |  
 | (o)(o)  
 C      _) 
  | ,___|  
  |   /
Al final eras Bart pero cuando vende el alma. Fin");
                break;
            case 69:
                Terminal.WriteLine(@"
____   ________  ___
\   \ /   /\   \/  /
 \   Y   /  \     / 
  \     /   /     \ 
   \___/   /___/\  \
                 \_/
Galactico Wins. Fatality.");
                break;

        }
          
    }
}
