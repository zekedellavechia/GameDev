using UnityEngine;

public class Hacker : MonoBehaviour
{

    //GAME CONFIG
    const string menuHint = "Escribe menu para regresar!";
    string[] level1passwords = { "batistuta", "maradona", "messi", "banega", "mascherano", "kempes"};
    string[] level2passwords = { "veron", "schelotto", "palermo", "castroman", "almada", "zaracho", "de la cruz", "almendra", "santos borre", "martinez quarta", "ferrari" };
    string[] level3passwords = { "ronaldinho", "rivaldo", "dida", "kaka", "roberto carlos", "pele" };
    string[] level69passwords = { "galactico", "emmux vx", "el gran cono mayor" };


    int level;

    enum Screen { MainMenu, Password, Win}
    Screen currentScreen;
    string password;
    void Start()
    {
        //this print works in the Console of unity
        ShowMainMenu("Bienvenido Crack!");


        
    }



    private void ShowMainMenu(string greeting)
    {
        //string nombre = "Benito";
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Tienes que advinar el jugador de fútbol (todo en minusculas porque esta programado asi)");
        Terminal.WriteLine("Elige el nivel:");
        Terminal.WriteLine("Pon 1 para Selección Argentina");
        Terminal.WriteLine("Pon 2 para Liga Argentina");
        Terminal.WriteLine("Pon 3 para Brasil");
        //Terminal.WriteLine("Choose your destiny " + nombre + ": ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            Terminal.ClearScreen();
            ShowMainMenu("Bienvenido de vuelta Crack!");
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
        Terminal.WriteLine("Pon el Password (nombre del jugador) para ganar, pista: " + password.Anagram());
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
        ____
       ( () )
        \  /
         ||
         ||
        [__]
Adivinaste, eres crack!.");
                break;
            case 2:
                Terminal.WriteLine(@"
                     ___
 o__        o__     |   |\
/|          /\      |   |X\
/ > o        <\     |   |XX\
Adivinaste, eres crack!.");
            break;
            case 3:
                Terminal.WriteLine(@"

        ____
       ( () )
        \  /
         ||
         ||
        [__]
Adivinaste, eres crack!");
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
