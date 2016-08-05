using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Project_Akiko
{
    public class Log
    {
        public static void System(string args, bool line)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[SYSTEM] ");
            Console.ResetColor();
            if (line == true)
            {
                Console.WriteLine(args);
            }
            else
            {
                Console.Write(args);
            }
        }
        public static void Info(string args, bool line)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[INFO] ");
            if (line == true)
            {
                Console.WriteLine(args);
            }
            else
            {
                Console.Write(args);
            }
            Console.ResetColor();
        }
        public static void Error(string args, bool line)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[ERROR] ");
            Console.ResetColor();
            if (line == true)
            {
                Console.WriteLine(args);
            }
            else
            {
                Console.Write(args);
            }
        }
    }


    public class Global
    {
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);
        // System variables
        public static string Mode;
        public static string UserInput = " ";
        public static string AkikoReply = " ";
        public static bool ExitBool = false;
        public static string MusicDirectory = @"..\..\..\..\..\..\..\Music\Playlists\";
        public static string VoiceOutputDirectory = "\"C:\\Users\\hoang\\OneDrive\\Documents\\Visual Studio 2015\\Projects\\Project Akiko\\Project Akiko\\bin\\Debug\\Voice Output\"";
        public static string ProgramName = @"Project Akiko.exe";
        public static bool ForceExit = false;
        public const int KEYEVENTF_EXTENTEDKEY = 1;
        public const int KEYEVENTF_KEYUP = 0;
        public const int VK_MEDIA_NEXT_TRACK = 0xB0;
        public const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        public const int VK_MEDIA_PREV_TRACK = 0xB1;
        public const int Delay = 3000;
        public static string Status = "neutral";
        public static int Interest = 0;
        public static int AwaitingAnswer = 0;
        public static int ContinousHello = 0;
        public static string MusicChoice = "null";
        public static bool MusicPlay = true;
        // Text Output Templates
        public static string[] Annoyed;
        public static string[] Disappointed;
        public static string[] TurnOff;
        public static string[] GeneralGreeting;
        public static string[] HelloChain;
        public static string[] InputError;
        public static string[] NeutralResponse;
        public static string[] NextMusic;
        public static string[] Pity;
        public static string[] PositiveResponse;
        public static string[] SelectMusic;
        public static string[] StartMusic;
        public static string[] StartMusicFalseFirst;
        public static string[] ToggleMusic;
        public static string[] WorriedResponse;
        // Input Processing Templates
        public static string[] GreetArray;
        public static string[] GreetMorningArray;
        public static string[] GreetAfternoonArray;
        public static string[] GreetEveningArray;
        public static string[] GreetReturnArray;
        public static string[] MusicStartArray1;
        public static string[] MusicStartArray2;
        public static string[] MusicStartArray3;
        public static string[] MusicToggleArray;
        public static string[] MusicNextArray;
        public static string[] MusicPrevArray;
        public static string[] PositiveArray;
        public static string[] NegativeArray;
        public static string[] GoodStatusArray;
        public static string[] BadStatusArray;
        public static string[] ExitArray;
        public static string[] RestartArray;
        // Music Playlist Templates
        public static int AlbumCount = 3;
        public static string[] AllPlaylists;
        public static string[] AllMusic1 = { " all 1 ", " all1 ", " 1 " };
        public static string[] AllMusic2 = { " all 2 ", " all2 ", " 2 " };
        public static string[] Piano3 = { " piano 3 ", " piano3 ", " 3 " };
        // Startup Report
        public static void StartupResport()
        {   
            Log.System("Initilized variables", true);
            // Load Settings
            Global.Mode = Properties.Settings.Default.InputMode;
            // Get Input Templates
            Global.GreetArray = System.IO.File.ReadAllLines(@"Input Templates\Greeting\GreetArray.txt");
            for (int i = 0; i < GreetArray.Length; i++) { GreetArray[i] = Input.AdjustString(GreetArray[i]); }
            Global.GreetMorningArray = System.IO.File.ReadAllLines(@"Input Templates\Greeting\GreetMorningArray.txt");
            for (int i = 0; i < GreetMorningArray.Length; i++) { GreetMorningArray[i] = Input.AdjustString(GreetMorningArray[i]); }
            Global.GreetAfternoonArray = System.IO.File.ReadAllLines(@"Input Templates\Greeting\GreetAfternoonArray.txt");
            for (int i = 0; i < GreetAfternoonArray.Length; i++) { GreetAfternoonArray[i] = Input.AdjustString(GreetAfternoonArray[i]); }
            Global.GreetEveningArray = System.IO.File.ReadAllLines(@"Input Templates\Greeting\GreetEveningArray.txt");
            for (int i = 0; i < GreetEveningArray.Length; i++) { GreetEveningArray[i] = Input.AdjustString(GreetEveningArray[i]); }
            Global.GreetReturnArray = System.IO.File.ReadAllLines(@"Input Templates\Greeting\GreetReturnArray.txt");
            for (int i = 0; i < GreetReturnArray.Length; i++) { GreetReturnArray[i] = Input.AdjustString(GreetReturnArray[i]); }
            Global.MusicStartArray1 = System.IO.File.ReadAllLines(@"Input Templates\Music\MusicStartArray1.txt");
            for (int i = 0; i < MusicStartArray1.Length; i++) { MusicStartArray1[i] = Input.AdjustString(MusicStartArray1[i]); }
            Global.MusicStartArray2 = System.IO.File.ReadAllLines(@"Input Templates\Music\MusicStartArray2.txt");
            for (int i = 0; i < MusicStartArray2.Length; i++) { MusicStartArray2[i] = Input.AdjustString(MusicStartArray2[i]); }
            Global.MusicStartArray3 = System.IO.File.ReadAllLines(@"Input Templates\Music\MusicStartArray3.txt");
            for (int i = 0; i < MusicStartArray3.Length; i++) { MusicStartArray3[i] = Input.AdjustString(MusicStartArray3[i]); }
            Global.MusicToggleArray = System.IO.File.ReadAllLines(@"Input Templates\Music\MusicToggleArray.txt");
            for (int i = 0; i < MusicToggleArray.Length; i++) { MusicToggleArray[i] = Input.AdjustString(MusicToggleArray[i]); }
            Global.MusicNextArray = System.IO.File.ReadAllLines(@"Input Templates\Music\MusicNextArray.txt");
            for (int i = 0; i < MusicNextArray.Length; i++) { MusicNextArray[i] = Input.AdjustString(MusicNextArray[i]); }
            Global.MusicPrevArray = System.IO.File.ReadAllLines(@"Input Templates\Music\MusicPrevArray.txt");
            for (int i = 0; i < MusicPrevArray.Length; i++) { MusicPrevArray[i] = Input.AdjustString(MusicPrevArray[i]); }
            Global.PositiveArray = System.IO.File.ReadAllLines(@"Input Templates\Answer\PositiveArray.txt");
            for (int i = 0; i < PositiveArray.Length; i++) { PositiveArray[i] = Input.AdjustString(PositiveArray[i]); }
            Global.NegativeArray = System.IO.File.ReadAllLines(@"Input Templates\Answer\NegativeArray.txt");
            for (int i = 0; i < NegativeArray.Length; i++) { NegativeArray[i] = Input.AdjustString(NegativeArray[i]); }
            Global.GoodStatusArray = System.IO.File.ReadAllLines(@"Input Templates\Answer\GoodStatusArray.txt");
            for (int i = 0; i < GoodStatusArray.Length; i++) { GoodStatusArray[i] = Input.AdjustString(GoodStatusArray[i]); }
            Global.BadStatusArray = System.IO.File.ReadAllLines(@"Input Templates\Answer\BadStatusArray.txt");
            for (int i = 0; i < BadStatusArray.Length; i++) { BadStatusArray[i] = Input.AdjustString(BadStatusArray[i]); }
            Global.ExitArray = System.IO.File.ReadAllLines(@"Input Templates\System Control\ExitArray.txt");
            for (int i = 0; i < ExitArray.Length; i++) { ExitArray[i] = Input.AdjustString(ExitArray[i]); }
            Global.RestartArray = System.IO.File.ReadAllLines(@"Input Templates\System Control\RestartArray.txt");
            for (int i = 0; i < RestartArray.Length; i++) { RestartArray[i] = Input.AdjustString(RestartArray[i]); }
            Global.AllPlaylists = System.IO.File.ReadAllLines(@"Input Templates\Playlists\AllPlaylists.txt");
            for (int i = 0; i < AllPlaylists.Length; i++) { AllPlaylists[i] = Input.AdjustString(AllPlaylists[i]); }
            // Text Output Templates
            Global.Annoyed = System.IO.File.ReadAllLines(@"Text Output\Annoyed.txt");
            Global.Disappointed = System.IO.File.ReadAllLines(@"Text Output\Disappointed.txt");
            Global.TurnOff = System.IO.File.ReadAllLines(@"Text Output\TurnOff.txt");
            Global.GeneralGreeting = System.IO.File.ReadAllLines(@"Text Output\GeneralGreeting.txt");
            Global.HelloChain = System.IO.File.ReadAllLines(@"Text Output\HelloChain.txt");
            Global.InputError = System.IO.File.ReadAllLines(@"Text Output\InputError.txt");
            Global.NeutralResponse = System.IO.File.ReadAllLines(@"Text Output\NeutralResponse.txt");
            Global.NextMusic = System.IO.File.ReadAllLines(@"Text Output\NextMusic.txt");
            Global.Pity = System.IO.File.ReadAllLines(@"Text Output\Pity.txt");
            Global.PositiveResponse = System.IO.File.ReadAllLines(@"Text Output\PositiveResponse.txt");
            Global.SelectMusic = System.IO.File.ReadAllLines(@"Text Output\SelectMusic.txt");
            Global.StartMusic = System.IO.File.ReadAllLines(@"Text Output\StartMusic.txt");
            Global.StartMusicFalseFirst = System.IO.File.ReadAllLines(@"Text Output\StartMusicFalseFirst.txt");
            Global.ToggleMusic = System.IO.File.ReadAllLines(@"Text Output\ToggleMusic.txt");
            Global.WorriedResponse = System.IO.File.ReadAllLines(@"Text Output\WorriedResponse.txt");
            Log.System("Done loading variables", true);
        }
        public static void Exit()
        {
            Global.ExitBool = true;
        }
    }


    public class Input
    {
        public static void Text()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[USER] ");
            Global.UserInput = Console.ReadLine();
            Console.ResetColor();
            Global.UserInput = AdjustString(Global.UserInput);
            Process.Input();
        }
        public static string AdjustString(string str)
        {
            if (str == "") { return ""; }
            else 
            { 
                StringBuilder sb = new StringBuilder();
                foreach (char c in str)
                {
                    if ((c == '!') || (c == '.') || (c == '?') || (c == ',')) { }
                    else
                    {
                        sb.Append(c);
                    }
                }
                string CurrentString = sb.ToString();
                if ((char.IsWhiteSpace(CurrentString,0) == false) && (char.IsWhiteSpace(CurrentString,CurrentString.Length - 1) == false))
                {
                    return " " + CurrentString + " ";
                }
                else
                {
                    if (char.IsWhiteSpace(CurrentString, 0))
                    {
                        return CurrentString + " ";
                    }
                    else
                    {
                        return " " + CurrentString;
                    }
                }
            }
        }
        public static void Voice()
        {

        }
    }


    public class Task
    {
        public static void PlayMusic(string args, bool online)
        {
            if (online == false)
            {
                if (Process.Check(args, Global.AllMusic1))
                {
                    System.Diagnostics.Process.Start(Global.MusicDirectory + @"All1.wpl");
                    Global.MusicChoice = "All Da MOOSIC! Vol. 1";
                    Global.MusicPlay = true;
                }
                else if (Process.Check(args, Global.AllMusic2))
                {
                    System.Diagnostics.Process.Start(Global.MusicDirectory + @"All2.wpl");
                    Global.MusicChoice = "All Da MOOSIC! Vol. 2";
                    Global.MusicPlay = true;
                }
                else if (Process.Check(args, Global.Piano3))
                {
                    System.Diagnostics.Process.Start(Global.MusicDirectory + @"Piano3.wpl");
                    Global.MusicChoice = "Animenz Piano Collection Vol. 3";
                    Global.MusicPlay = true;
                }
                else 
                {
                    Global.MusicPlay = false;
                }
            }
            else
            {

            }
        }
        public static void NextMusic()
        {
            Global.keybd_event(Global.VK_MEDIA_NEXT_TRACK, 0, Global.KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
            Log.Info("Started next track.", true);
        }
        public static void ToggleMusic()
        {
            Global.keybd_event(Global.VK_MEDIA_PLAY_PAUSE, 0, Global.KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
            Log.Info("Toggled music playback.", true);
        }
    }


    public class Process
    {
        public static bool Check(string StringToCheck, string[] StringArray)
        {
            if (StringArray.Any(StringToCheck.Contains)) { return true; }
            else { return false; }
        }
        public static bool CheckAll(string StringToCheck, string[] StringArray)
        {
            if (StringArray.All(StringToCheck.Contains)) { return true; }
            else { return false; }
        }
        public static void Input()
        {
            Random r = new Random();
            Global.UserInput = Global.UserInput.ToLower();
            if (Process.Check(Global.UserInput, Global.GreetArray)){
                if (Global.ContinousHello < 3)
                {
                    Global.ContinousHello += 1;
                    Output.GeneralGreeting(r.Next(0, Global.GeneralGreeting.Length - 1));
                }
                else if (Global.ContinousHello > 4)
                {
                    Output.Annoyed(r.Next(0, Global.Annoyed.Length - 1));
                }
                else
                {
                    Global.ContinousHello += 1;
                    Output.HelloChain(r.Next(0, Global.HelloChain.Length - 1));
                }
            }
            else if ((Process.CheckAll(Global.UserInput, Global.MusicStartArray1)) || (Process.CheckAll(Global.UserInput, Global.MusicStartArray2)) || (Process.CheckAll(Global.UserInput, Global.MusicStartArray3)))
            {
                if (Process.Check(Global.UserInput, Global.AllPlaylists))
                {
                    Global.MusicChoice = Global.UserInput;
                    Output.StartMusic(r.Next(0, Global.StartMusic.Length - 1));
                }
                else
                {
                    Global.MusicChoice = "wait";
                    Output.SelectMusic(r.Next(0, Global.SelectMusic.Length - 1));
                }
            }
            else if (Process.Check(Global.UserInput, Global.MusicToggleArray))
            {
                Global.MusicPlay = false;
                Output.ToggleMusic(r.Next(0, Global.ToggleMusic.Length - 1));
            }
            else if (Process.Check(Global.UserInput, Global.MusicNextArray))
            {
                Global.MusicPlay = false;
                Output.NextMusic(r.Next(0, Global.NextMusic.Length - 1));
            }
            else if (Process.Check(Global.UserInput, Global.PositiveArray))
            {
                if ((Global.AwaitingAnswer == 1) || (Global.AwaitingAnswer == 5))
                {
                    Global.AwaitingAnswer = 0;
                    Output.PositiveResponse(r.Next(0, Global.PositiveResponse.Length - 1));
                }
                else
                {
                    Output.InputError(r.Next(0, Global.InputError.Length - 1));
                }
            }
            else if (Process.Check(Global.UserInput, Global.NegativeArray))
            {
                if (Global.AwaitingAnswer == 1)
                {
                    Global.AwaitingAnswer = 0;
                    Output.Disappointed(r.Next(0, Global.Disappointed.Length - 1));
                }
                else if (Global.AwaitingAnswer == 5)
                {
                    Global.AwaitingAnswer = 0;
                    Output.Annoyed(r.Next(0, Global.Annoyed.Length - 1));
                }
                else
                {
                    Output.InputError(r.Next(0, Global.InputError.Length - 1));
                }
            }
            else if (Process.Check(Global.UserInput, Global.GoodStatusArray))
            {
                if (Global.AwaitingAnswer == 2)
                {
                    Global.AwaitingAnswer = 0;
                    Output.PositiveResponse(r.Next(0, Global.PositiveResponse.Length - 1));
                }
                else
                {
                    Output.InputError(r.Next(0, Global.InputError.Length - 1));
                }
            }
            else if (Process.Check(Global.UserInput, Global.BadStatusArray))
            {
                if (Global.AwaitingAnswer == 2)
                {
                    Global.AwaitingAnswer = 0;
                    Output.WorriedResponse(r.Next(0, Global.WorriedResponse.Length - 1));
                }
                else
                {
                    Output.InputError(r.Next(0, Global.InputError.Length - 1));
                }
            }
            else if (Process.Check(Global.UserInput, Global.ExitArray))
            {
                Output.Exit(r.Next(0, Global.TurnOff.Length - 2), false);
            }
            else if (Process.Check(Global.UserInput, Global.RestartArray))
            {
                Output.Exit(r.Next(0, Global.TurnOff.Length - 2), true);
            }
            else
            {
                if (Global.AwaitingAnswer == 3)
                {
                    Global.AwaitingAnswer = 0;
                    Output.NeutralResponse(r.Next(0, Global.NeutralResponse.Length - 1));
                }
                else if (Global.AwaitingAnswer == 4)
                {
                    Global.AwaitingAnswer = 0;
                    Output.Pity(r.Next(0, Global.Pity.Length - 1));
                }
                else if (Global.MusicChoice == "wait")
                {
                    Global.MusicChoice = Global.UserInput;
                    Output.StartMusic(r.Next(0, Global.StartMusic.Length - 1));
                }
                else
                {
                    Output.InputError(r.Next(0, Global.InputError.Length - 1));
                }
            }
        }
    }


    public class Output
    {
        Random r = new Random();
        public static void Write(string args, bool recurse)
        {
            if (args != "")
            {
                Console.Write("[AKIKO] ");
                Console.WriteLine(args);
            }
            if (recurse == true) { Input.Text(); }
        }
        public static void Voice(string type, int version)
        {
            string dir = Global.VoiceOutputDirectory + @"\" + type + @"\" + version.ToString() + ".wav";
            System.Diagnostics.Process.Start(@"Voice Output\VoiceHandler.vbs", dir);
        }
        public static void GeneralGreeting(int args)
        {
            switch (args)
            {
                case 0: Global.AwaitingAnswer = 3; break;
                case 1: case 2: Global.AwaitingAnswer = 2; break;
                default: break;
            }
            Output.Voice("GeneralGreeting", args);
            Output.Write(Global.GeneralGreeting[args], true);
        }
        public static void HelloChain(int args)
        {
            switch (args)
            {
                case 1: case 2: Global.AwaitingAnswer = 5; break;
                default: break;
            }
            Output.Voice("HelloChain", args);
            Output.Write(Global.HelloChain[args], true);
        }
        public static void StartMusic(int args)
        {
            Task.PlayMusic(Global.MusicChoice, false);
            if (Global.MusicPlay == true)
            {
                Output.Write(Global.StartMusic[args] + " " + Global.MusicChoice + ".", false);
            }
            else
            {
                Output.Write(Global.StartMusicFalseFirst[args] + Global.MusicChoice.Remove(Global.MusicChoice.Length - 1) + ".", false);
            }
            if (Global.MusicPlay == true) { Log.Info("Now playing " + Global.MusicChoice + ".", true); }
            Input.Text();
        }
        public static void SelectMusic(int args)
        {
            Output.Voice("SelectMusic", args);
            Output.Write(Global.SelectMusic[args], true);
        }
        public static void ToggleMusic(int args)
        {
            Output.Voice("ToggleMusic", args);
            Output.Write(Global.ToggleMusic[args], false);
            Task.ToggleMusic();
            Input.Text();
        }
        public static void NextMusic(int args)
        {
            Output.Voice("NextMusic", args);
            Output.Write(Global.NextMusic[args], false);
            Task.NextMusic();
            Input.Text();
        }
        public static void PositiveResponse(int args)
        {
            Output.Voice("PositiveResponse", args);
            Output.Write(Global.PositiveResponse[args], true);
        }
        public static void Annoyed(int args)
        {
            Random r = new Random();
            Output.Voice("Annoyed", args);
            Output.Write(Global.Annoyed[args], false);
            if (args < 6) { Output.Exit(r.Next(7, 11), false); }
            else { Input.Text(); }
        }
        public static void Disappointed(int args)
        {
            Output.Voice("Disappointed", args);
            Output.Write(Global.Disappointed[args], true);
        }
        public static void WorriedResponse(int args)
        {
            if (args < 3)
            {
                Global.AwaitingAnswer = 4;
            }
            Output.Voice("WorriedResponse", args);
            Output.Write(Global.WorriedResponse[args], false);
            Input.Text();
        }
        public static void NeutralResponse(int args)
        {
            Output.Voice("NeutralResponse", args);
            Output.Write(Global.NeutralResponse[args], true);
        }
        public static void Pity(int args)
        {
            Output.Voice("Pity", args);
            Output.Write(Global.Pity[args], true);
        }
        public static void InputError(int args)
        {
            Output.Voice("InputError", args);
            Output.Write(Global.InputError[args], true);
        }
        public static void Exit(int args, bool restart)
        {
            if (restart == true)
            {
                Global.ForceExit = true;
                System.Diagnostics.Process.Start(Global.ProgramName);
            }
            Output.Voice("TurnOff", args);
            Output.Write(Global.TurnOff[args], false);
            Global.Exit();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Global.StartupResport();
            Log.System("Successful startup!", true);
            ModeSelect();
            if (Global.Mode == "text")
            {
                Log.System("Entering text input mode.", true);
                Input.Text();
            }
            else
            {
                Log.System("Entering voice input mode.", true);
                Input.Voice();
            }
            if (Global.ExitBool == false)
            {
                Log.Error("Unexpected error occured. Press any key to exit ...", true);
            }
            else
            {
                Log.System("Shutting down system ...", true);
                Log.Info("Akiko went offline. Press any key to exit ...", true);
            }
            if (Global.ForceExit == false) { Console.ReadKey(); }
        }
        static void ModeSelect()
        {
            if ((Global.Mode == "text") || (Global.Mode == "voice"))
            {
                Log.System("Detected default mode as " + Global.Mode + ".", true);
            }
            else
            {
                Log.System("Default mode not set.", true);
                Log.Info("Enter text/voice to select input mode: ", false);
                Global.Mode = Console.ReadLine().ToLower();
                switch (Global.Mode)
                {
                    case "text":
                    case "t":
                    case "1":
                        Global.Mode = "text";
                        break;
                    case "voice":
                    case "v":
                    case "2":
                        Global.Mode = "voice";
                        break;
                    default:
                        Log.Error("Invalid input. Try again.", true);
                        ModeSelect();
                        break;
                }
            }  
        }
    }
}