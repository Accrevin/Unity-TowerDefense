using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace Composer
{
    internal class Program
    {
        static void CalculateFrequency(int[] FrequencyList, string[] noteList)
        {
            for (int i = 0; i < noteList.Length; i++)
            {
                //use A4 as a reference
                double reference = 440.0;
                int[] LengthFromReference = { 2, 3, 5, 7, 8, 10, 12 };
                if (noteList[i].Length >= 1)
                {
                    if (noteList[i].Length == 2 && noteList[i][1] == 'b')
                    {
                        //Get just the Note part of the string
                        char note = noteList[i][0];
                        int noteIndex = Array.IndexOf(new char[] { 'B', 'C', 'D', 'E', 'F', 'G', 'A' }, note);
                        Console.WriteLine(noteIndex);
                        //flat so its one semitone below default note
                        int noteLocation = (noteIndex - 1) % LengthFromReference.Length;
                        //calculate + add to list
                        FrequencyList[i] = Convert.ToInt32(reference * Math.Pow(2.0, noteLocation / 12.0));

                    }

                    //see if the string contains #
                    else if (noteList[i].Length == 2 && noteList[i].Contains('#'))
                    {
                        //Get just the note so we can use LengthFromReference to get number of semimtones away from reference frequency (also make it capital so search works)
                        char note = noteList[i][0];
                        int noteIndex = Array.IndexOf(new char[] { 'B', 'C', 'D', 'E', 'F', 'G', 'A' }, note);
                        //Sharp so its one semitone up
                        int noteLocation = (noteIndex + 1) % LengthFromReference.Length;
                        //calculate and add to list
                        FrequencyList[i] = Convert.ToInt32(reference * Math.Pow(2.0, noteLocation / 12.0));

                    }

                    else
                    {
                        //calculate and add to list
                        int noteIndex = Array.IndexOf(new string[] { "B", "C", "D", "E", "F", "G", "A" }, noteList[i]);
                        FrequencyList[i] = Convert.ToInt32(reference * Math.Pow(2.0, noteIndex / 12.0));
                    }
                }

                else
                {
                    Console.WriteLine($"Invalid note format at index {i + 1}: {noteList[i]}");
                    continue;
                }

            }
        }

        static void ConvertDuration(string[] LengthList, int[] DurationArray)
        {
            int[] DurationList = [250, 500, 1000];
            for (int i = 0; i < LengthList.Length; i++)
            {
                int DurationReferenced = Array.IndexOf(new string[]{"1/4", "1/2", "1" }, LengthList[i]);
                DurationArray[i] = DurationList[DurationReferenced];

            }
        }

        static void PlayNotes(int[] notes, int[] duration)
        {
            for (int i = 0; i < notes.Length; i++)
            {
                Console.Beep(notes[i], duration[i]);
            }
        }

        static void Main(string[] args)
        {
            // lists to store notes and timings
            List<String> NoteList = new List<String>();
            List<String> DurationList = new List<String>();

            bool RunProgram = true;
            while (RunProgram)
            {
                // Take input
                Console.WriteLine("Enter the note and duration of the note.\nType show to show saved notes\nType del to delete last inputted note\nType done when done");
                string Answer = Console.ReadLine();

                // Separate Note from time
                String[] SplitInput = Answer.Split(' ');

                if (SplitInput.Length == 2)
                {
                    // First thing in the list should be the note
                    string note = SplitInput[0];
                    // Second thing in the list should be the length
                    string length = SplitInput[1];
                    if (note.Length == 2 && note[1] == 'b')
                    {
                        char UppercaseNote = Char.ToUpper(note[0]);
                        string BaseNote = Char.ToString(note[0]);
                        string WholeNote = BaseNote + "b";
                        NoteList.Add(WholeNote);
                    }

                    else
                    {
                        NoteList.Add(note.ToUpper());
                    }
                    
                    DurationList.Add(length);
                }
                else if (Answer == "del")
                {
                    // Delete most recent addition from both lists
                    if (NoteList.Count > 0)
                    {
                        NoteList.RemoveAt(NoteList.Count - 1);
                        DurationList.RemoveAt(DurationList.Count - 1);
                    }
                    else
                    {
                        Console.WriteLine("No notes to delete.");
                    }
                }
                else if (Answer == "show")
                {
                    // Print lists
                    for (int i = 0; i < NoteList.Count; i++)
                    {
                        Console.WriteLine(NoteList[i] + " " + DurationList[i]);
                    }
                }
                else if (Answer == "done")
                {
                    // List to store calculated note frequencies
                    int[] frequencies = new int[NoteList.Count];
                    // List to store list of converted note duration
                    int[] DurationConvert = new int[NoteList.Count];

                    // Convert list of notes to array
                    string[] NoteArray = NoteList.ToArray();
                    // Convert list of duration to array
                    string[] DurationArray = DurationList.ToArray();

                    CalculateFrequency(frequencies, NoteArray);
                    ConvertDuration(DurationArray, DurationConvert);
                    PlayNotes(frequencies, DurationConvert);
                    RunProgram = false;
                }

                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
//I honestly just blacked out for a few hours and woke up to code. I probably wont be able to tell you exactly what i wrote cause im not sure either 