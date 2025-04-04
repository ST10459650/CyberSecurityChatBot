using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CyberSecurityChatBot
{

    class ChatBot  //... a class to encapsulate properties and methods for the Bot.
    {

        public string userName { get; set; } = "Guest";  // automatic property to store the user's name and an appropriate output otherwise .

        public string welcomeMessage { get; set; } = "Welcome to Cybersecurity Awareness Bot!"; //...property for the welcome message.

        public void ToRun() //method to run the chatbot: plays voice greeting, displays logo, and starts interaction.
        {
            PlayVoiceGreeting(); //...method calls for the logic within the mentioned methods
            DisplayAsciiLogo();
            InitiateChat();
        }

        private void PlayVoiceGreeting() // method to play the recorded voice greeting.
        {
            // try-catch statement to handle invalid inputs

            try 
            {
                 SoundPlayer playFrequency = new SoundPlayer("greeting.wav"); //object from the class SoundPlayer class to allow the recording to play.
                playFrequency.PlaySync(); //play audio in-sync.
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error playing audio: {e.Message}"); 
            }
        }

        private void DisplayAsciiLogo() //...method that has the logic to display the logo.
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow; //...line to change the colour of the logo to enhance the visual appeal of the bot.
            Console.WriteLine(@"
     ██████╗ ██╗   ██╗███████╗
    ██╔═══██╗██║   ██║██╔════╝
    ██║   ██║██║   ██║███████╗
    ██║▄▄ ██║██║   ██║╚════██║
    ╚██████╔╝╚██████╔╝███████║
     ╚══▀▀═╝  ╚═════╝ ╚══════╝

   CYBERSECURITY AWARENESS BOT
            ");
            Console.ResetColor();
        }

        private void InitiateChat() // the method that starts the interaction between the user and bot.
        {

            Console.WriteLine("\nHello! What's your name?");

            string inputName;
            inputName = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputName)) //...if the user enters a string of characters, the program accepts input and makes the appropriate formatting.
            {
                userName = char.ToUpper(inputName.Trim()[0]) + inputName.Trim().Substring(1).ToLower(); //...to capitalize the first letter and trim any extra spaces.
            }

            Console.ForegroundColor = ConsoleColor.Blue; //...to change the colour of the welcoming message, (using string formatting).
            Console.WriteLine($"\n===== {welcomeMessage} =====");
            Console.ResetColor(); //...terminates the effect!

            Console.WriteLine($"Welcome, {userName}! How can I assist you with cybersecurity today.");

            ChatLoop(); //calls the corresponding method.
        }

        private void ChatLoop()  
        {
            while (true)  
            {
                Console.Write("\nYou: ");

                string userInput;
                userInput = Console.ReadLine()?.ToLower(); // ...reads user input and converts it to lowercase!

                //Checks if the user wants to exit and allows the action, when the string of characters in lowercase 'exit' is entered

                if (userInput == "exit") 
                {
                    Console.WriteLine("Chatbot: Stay safe online! Goodbye!");
                    break;
                }

                string response;
                response = GetBotResponse(userInput); // method is called to generate the chatbot's responses based on the user input.

                TypeEffect($"Chatbot: {response}"); //...a method is called to simulate a typing effect for the responses.
            }
        }

        private string GetBotResponse(string input) //...method containing the expected user inputs and their corresponding responses
        {

            if (input.Contains("how are you"))
                return "I'm just a bot, but I'm here to help you stay secure!";

            if (input.Contains("what's your purpose"))
                return "I educate users about cybersecurity and safe online practices.";

            if (input.Contains("what can i ask you about"))
                return "You can ask me about password safety, phishing scams, and safe browsing.";

            if (input.Contains("password safety"))
                return "Use strong passwords with a mix of letters, numbers, and symbols. Avoid using the same password everywhere!";

            if (input.Contains("phishing"))
                return "Phishing scams are deceptive attempts to steal your info. Avoid suspicious emails and links!";

            if (input.Contains("safe browsing"))
                return "Always check for HTTPS in websites and be cautious with your personal data online.";

            return "I didn’t quite understand that. Could you rephrase?"; // input validation: default response when an invalid input is entered.
        }

        private void TypeEffect(string message)
        {

            foreach (char a in message)
            {
                Console.Write(a);
                Thread.Sleep(30); // Delay in milliseconds between characters
            }
            Console.WriteLine(); //moves to the next line
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            //...instance of the ChatBot 

            ChatBot bot = new ChatBot();
            bot.ToRun();
        }
    }
}
