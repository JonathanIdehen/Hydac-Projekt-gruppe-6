using System;
using System.Collections.Generic;
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
            foreach (Meeting element in SavedMeetings)
            {
                if (element != null)
                {
                    try
                    {
                        StreamWriter sw = new StreamWriter(filePath);
                        sw.WriteLine(element.GetMeetingContents());
                        sw.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Exception: {e.Message}");
                    }
                }
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

                    string meetingName;
                    DateTime meetingDate;
                    string meetingEmployee;
                    Room meetingRoom;

                    sr = new StreamReader(filePath);
                    meetingCount = 0;
                    while (!sr.EndOfStream) { meetingCount++; }
                    sr.Close();
                    savedMeetings = new Meeting[meetingCount + 10]; //can hold all saved meetings + 10 extra

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
                else
                {
                    savedMeetings = new Meeting[10];
                }
            }
            catch (Exception readingFile)
            {
                Console.WriteLine($"Exception: {readingFile.Message}");
            }
        }

        public void DeleteMeetingsInFile(string filePath)
        {
            File.Delete(filePath);
        }
    }
}
