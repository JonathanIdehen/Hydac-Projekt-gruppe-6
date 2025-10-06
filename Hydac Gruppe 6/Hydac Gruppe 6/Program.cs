using System.Xml.Linq;

namespace Hydac_Gruppe_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //initialize existing rooms
            Room[] roomArray = new Room[14];
            roomArray[0] = new Room("#DK-LGS_Lokale_lille_Stue", 1);
            roomArray[1] = new Room("#DK-LGS_Lokale_Stilling_Kantine", 2);
            roomArray[2] = new Room("#DK-LGS_Lokale_Stilling_Stueetage", 3);
            roomArray[3] = new Room("#DK-LGS_Lokale_The_Aqaurium", 4);
            roomArray[4] = new Room("#DK-LGS_Lokale_The_Bridge-East", 5);
            roomArray[5] = new Room("#DK-LGS_Lokale_The_Bridge_West", 6);
            roomArray[6] = new Room("#DK-LGS_Lokale_The_Canteen-North", 7);
            roomArray[7] = new Room("#DK-LGS_Lokale_The_Station-Platform_9¾", 8);
            roomArray[8] = new Room("#DK-LGS_Lokale_The_Station-The_coffee_shop", 9);
            roomArray[9] = new Room("#DK-LGS_Lokale_The_Station-The_Library", 10);
            roomArray[10] = new Room("#DK-LGS_Lokale_The_Training_Center", 11);
            roomArray[11] = new Room("#DK-LGS_Lokalelille", 12);
            roomArray[12] = new Room("#DK-LGS_Lokaleservice", 13);
            roomArray[13] = new Room("#DK-LGS_Lokalestor", 14);

            //regular variables
            int userType;
            int roomChoice;
            int savedMeetingsIndex;
            MeetingCatalogue tempForMeetings;
            //Meeting contents
            string meetingName;
            string meetingStringTime;
            DateTime meetingTime;
            string meetingEmployee;
            Room meetingRoom;

            //make new meetingCatalogue
            tempForMeetings = new MeetingCatalogue();

            //read saved meetings from file to the catalogue
            tempForMeetings.ReadMeetingsFromFile("HydacMeetings.txt");

            //welcome menu
            Console.WriteLine("Velkommen til Hydac!");
            Console.WriteLine("Hvis du er medarbejder, skriv 1. Hvis du er gæst, skriv 2");

            //user chooses 'medarbejder' or 'gæst'
            userType = int.Parse(Console.ReadLine());

            //choice leads to either 'medarbejder' or 'gæst' functions
            switch (userType)
            {
                case 1:
                    //show all rooms
                    Console.WriteLine("skriv rumnummer på ønskede lokale");
                    foreach (Room element in roomArray)
                    {
                        Console.WriteLine(element.RoomNumber + ". " + element.RoomName);
                    }

                    //user choice of room
                    roomChoice = int.Parse(Console.ReadLine());
                    meetingRoom = roomArray[roomChoice - 1];                    

                    //user input for Meeting constructor parameters
                    Console.WriteLine("skriv navn på møde");
                    meetingName = Console.ReadLine();
                    Console.WriteLine("skriv starttidspunkt på møde, format er '[MMM] [DD], [YYYY], [TT:MM]'");
                    meetingStringTime = Console.ReadLine();
                    meetingTime = DateTime.Parse(meetingStringTime);
                    Console.WriteLine("skriv navn på den ansvarlige medarbejder for mødet");
                    meetingEmployee = Console.ReadLine();

                    //call of meeting constructor (with chosen Room and other input)
                    Meeting myNewMeeting = new Meeting(meetingName, meetingTime, meetingEmployee, meetingRoom);

                    //update the savedMeetings array we read from file to start with
                    savedMeetingsIndex = 0;
                    while (savedMeetingsIndex < tempForMeetings.SavedMeetings.Length)
                    {
                        if (tempForMeetings.SavedMeetings[savedMeetingsIndex] == null)
                        {
                            tempForMeetings.SavedMeetings[savedMeetingsIndex] = myNewMeeting;
                        }
                        savedMeetingsIndex++;
                    }

                    //then write saved meetings to file from catalogue
                    tempForMeetings.WriteMeetingsToFile("HydacMeetings.txt");

                    //write out all info about the meeting we just booked
                    Console.Clear();
                    Console.WriteLine("Møde med følgende info er nu booket");
                    Console.WriteLine(tempForMeetings.SavedMeetings[savedMeetingsIndex - 1].GetMeetingContents().Replace(';', '\n'));

                    break;
                case 2:
                    //'gæst' functionality
                    break;
            }
        }
    }
}
