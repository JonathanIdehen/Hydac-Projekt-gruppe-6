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

        public void ReadMeetingsFromFile(string filePath)
        {
            try
            {
                StreamReader sr;

                if (File.Exists(filePath))
                {
                    string currentLine;
                    string[] currentLineParts;
                    int meetingCount;
                    int savedMeetingIndex;
                    CultureInfo english = new CultureInfo("en-UK");

                    string meetingName;
                    DateTime meetingDate;
                    string meetingEmployee;
                    Room meetingRoom;

                    sr = new StreamReader(filePath);
                    meetingCount = 0;
                    while (!sr.EndOfStream) 
                    { 
                        sr.ReadLine();
                        meetingCount++; 
                    }
                    sr.Close();
                    savedMeetings = new Meeting[meetingCount + 1]; //can hold all saved meetings + 1 extra

                    sr = new StreamReader(filePath);
                    savedMeetingIndex = 0;
                    while (!sr.EndOfStream)
                    {
                        currentLine = sr.ReadLine();
                        currentLineParts = currentLine.Split(';');

                        meetingName = currentLineParts[0];
                        meetingDate = DateTime.Parse(currentLineParts[1], english);
                        meetingEmployee = currentLineParts[3];
                        meetingRoom = new Room(currentLineParts[4], int.Parse(currentLineParts[5]));

                        savedMeetings[savedMeetingIndex] = new Meeting(meetingName, meetingDate, meetingEmployee, meetingRoom);
                        savedMeetingIndex++;
                    }
                    sr.Close();
                }
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

        public void DeleteMeetingsFile(string filePath)
        {
            File.Delete(filePath);
        }
    }
}
