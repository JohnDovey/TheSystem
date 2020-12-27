#include <iostream>
#include <string>
//////////////////////////////////////////////////
//                 The System  Ver: 0.0.1 Alpha //
//////////////////////////////////////////////////
//                Gaia Awakening                //
//////////////////////////////////////////////////
//  Author: John Dovey (c) 2020 GPL             //
//  Email: dovey.john@gmail.com                 //
//  https://johndovey.github.io/TheSystem/      //
//////////////////////////////////////////////////

using namespace std;

void TopLine(int MyLength)
{
    int i = 0; // Counter variable for the "for loop"
    //Top Line
    printf("\r\n");
    printf("%c", char(201)); // Top Left Corner

    for (i = 0; i < MyLength; i++)
    {
        printf("%c", char(205)); // Double line
    }
    printf("%c", char(187)); // Top right Corner
    // printf("%c", char(220)); // Top right Corner shadow
    cout << "\n";
}
void BottomLine(int MyLength)
{
    int i = 0;               // Counter variable for the "for loop"
    printf("%c", char(200)); // Bottom Left Corner
    for (i = 0; i < MyLength; i++)
    {
        printf("%c", char(205)); // Double line (240 Triple)
    }
    printf("%c", char(188)); // Bottom right Corner
    // printf("%c", char(219)); // Bottom right Corner shadow
    cout << "\n";
}
void ShadowLine(int MyLength)
{
    int i = 0;               // Counter variable for the "for loop"
    printf("%c", char(040)); // Bottom Left Corner Shadow
    for (i = 0; i < MyLength; i++)
    {
        printf("%c", char(219)); // Shadow line 205
    }
    printf("%c", char(219)); // Bottom right Corner Shadow
    printf("%c", char(219)); // Bottom right Corner shadow
    cout << "\n";
}
void MsgLine(string MyMsgLine)
{
    cout << char(186) << "" << MyMsgLine << "" << char(186) << "\r\n";
}
void MsgBox(string MyMsg)
{
    int count = MyMsg.length(); // Length of string to print
    TopLine(count);
    MsgLine(MyMsg);
    // Bottom Line
    BottomLine(count);
    //ShadowLine(count);
    return;
}
void BuildMenu(string MenuText)
{
    int MenuWidth = 50;

    string PadString;
    /* Pad the line with spaces using the length of the MenuText subtracted from the MenuWidth */
    int Padwidth = MenuWidth - MenuText.length(); // How much to pad
    PadString = string(Padwidth, ' ');
    MenuText = MenuText + PadString; // Create the menu line with the text padded with spaces
    TopLine(MenuWidth);
    MsgLine(MenuText);
    BottomLine(MenuWidth);
    //ShadowLine(MenuWidth);
    printf("\n");
    return;
}
int main(int, char **)
{
    // Constants
    string AppVersion = "0.0.1";
    string MenuText; // Text to display menu
    string xMsg;
    string MenuChoice;          // Menu Selection
    char AlphaCode = char(224); // Greek Alpha symbol
    char BetaCode = char(225);  // Greek Beta Symbol

    cout << string(25, '\n'); // Clear some space on the console

    xMsg = "Welcome to The System [Version:" + AppVersion + AlphaCode + "]";
    MsgBox(xMsg);
    xMsg = "Please Stand by for system integrity check ...";
    MsgBox(xMsg);
    MenuText = "[S]tatus E[x]it";
    BuildMenu(MenuText);
    MenuChoice = getchar();
    xMsg = "User Selected: " + MenuChoice;
    MsgBox(xMsg);
   /* switch (stol(MenuChoice))
    {
    case 1:
        cout << "S";
        break;
    case 2:
        cout << "E";
        break;
    default:
        cout << "qwerty";
        break;
    } */
    cin.get(); // Pause for keyboard input
}
