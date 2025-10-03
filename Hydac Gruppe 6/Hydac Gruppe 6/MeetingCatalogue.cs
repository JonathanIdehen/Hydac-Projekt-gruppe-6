using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hydac_Gruppe_6
{
    public class MeetingCatalogue
    {
        //backing fields
        private Meeting[] savedMeetings;

        //properties
        public Meeting[] SavedMeetings
        {
            set { savedMeetings = value; }
            get { return savedMeetings; }
        }

        //methods
        //writes this instances savedMeetings array to the given file path
        public void WriteMeetingsToFile(string filePath)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath);
                foreach (Meeting element in SavedMeetings)
                {
                    if (element != null)
                    {
                        sw.WriteLine(element.GetMeetingContents());
                    }
                }
                sw.Close();
            }
            catch(Exception writingFile)
            {
                Console.WriteLine($"Exception: {writingFile.Message}");
            }
        }

        //reads to this instances savedMeetings array from the given file path
        public void ReadMeetingsFromFile(string filePath)
        {
            try
            {
                StreamReader sr;

                //if file exists
                if (File.Exists(filePath))
                {
                    string currentLine;
                    string[] currentLineParts;
                    int meetingCount;
                    int savedMeetingIndex;

                    //getMeetingContents contents put into appropriate variables
                    string meetingName;
                    DateTime meetingDate;
                    string meetingEmployee;
                    Room meetingRoom;

                    //checks number of Meetings in file
                    //accordingly sets this MeetingCatalogue instances Meeting array field to be an appropriately sized array to hold them
                    //+1 so it can hold one extra if one is getting added during the programs lifetime
                    sr = new StreamReader(filePath);
                    meetingCount = 0;
                    while (!sr.EndOfStream) 
                    { 
                        sr.ReadLine();
                        meetingCount++; 
                    }
                    sr.Close();
                    savedMeetings = new Meeting[meetingCount + 1];

                    //for each line, which is a meeting, puts said meeting into the array we just set
                    sr = new StreamReader(filePath);
                    savedMeetingIndex = 0;
                    while (!sr.EndOfStream)
                    {
                        currentLine = sr.ReadLine();
                        currentLineParts = currentLine.Split(';');

                        meetingName = currentLineParts[0];
                        meetingDate = DateTime.Parse(currentLineParts[1]);
                        meetingEmployee = currentLineParts[3];
                        meetingRoom = new Room(currentLineParts[4], int.Parse(currentLineParts[5]));

                        savedMeetings[savedMeetingIndex] = new Meeting(meetingName, meetingDate, meetingEmployee, meetingRoom);
                        savedMeetingIndex++;
                    }
                    sr.Close();
                }
                // if file doesnt exist, sets this instances MeetingCatalogue instance to have one element of space for a newly created meeting. 
                else
                {
                    savedMeetings = new Meeting[1];
                }
            }
            catch (Exception readingFile)
            {
                Console.WriteLine($"Exception: {readingFile.Message}");
            }
        }

        //deletes file at given filepath
        public void DeleteMeetingsFile(string filePath)
        {
            File.Delete(filePath);
        }
    }
}
