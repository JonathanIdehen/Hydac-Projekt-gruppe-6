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
            string meetingName;
            string meetingStringTime;
            DateTime meetingTime;
            string meetingEmployee;
            int savedMeetingsIndex = 0;
            Room meetingRoom;
            MeetingCatalogue tempForMeetings = new MeetingCatalogue();
            Meeting[] savedMeetings;

            //read savedMeetings from file
            tempForMeetings.ReadMeetingsFromFile("HydacMeetings.txt");
            savedMeetings = tempForMeetings.SavedMeetings;

            //regular code
            Console.WriteLine("Velkommen til Hydac!");
            Console.WriteLine("Hvis du er medarbejder, skriv 1. Hvis du er gæst, skriv 2");

            userType = int.Parse(Console.ReadLine());

            switch (userType)
            {
                case 1:
                    //vis rum
                    Console.WriteLine("skriv rumnummer på ønskede lokale");
                    foreach (Room element in roomArray)
                    {
                        Console.WriteLine(element.RoomNumber + ". " + element.RoomName);
                    }

                    //vælg rum
                    roomChoice = int.Parse(Console.ReadLine());
                    meetingRoom = roomArray[roomChoice - 1];                    

                    //user input for meeting constructor parametre, og array af meetings kommer også med. 
                    Console.WriteLine("skriv navn på møde");
                    meetingName = Console.ReadLine();
                    Console.WriteLine("skriv starttidspunkt på møde, format er '[MMM] [DD], [YYYY], [TT:MM]'");
                    meetingStringTime = Console.ReadLine();
                    meetingTime = DateTime.Parse(meetingStringTime);
                    Console.WriteLine("skriv navn på den ansvarlige medarbejder for mødet");
                    meetingEmployee = Console.ReadLine();

                    //kald meeting constructor
                    Meeting myMeeting = new Meeting(meetingName, meetingTime, meetingEmployee, meetingRoom);

                    //derefter "gem" det instantierede møde i et array for at repræsentere persistens
                    if (savedMeetingsIndex < savedMeetings.Length)
                    {
                        savedMeetings[savedMeetingsIndex] = myMeeting;
                        savedMeetingsIndex++;
                    }

                    //then write savedMeetings to file
                    tempForMeetings.SavedMeetings = savedMeetings;
                    tempForMeetings.WriteMeetingsToFile("HydacMeetings.txt");

                    //test om mødet er puttet ind ordenligt
                    Console.Clear();
                    Console.WriteLine("Møde med følgende info er nu booket");
                    Console.WriteLine(savedMeetings[savedMeetingsIndex - 1].GetMeetingContents().Replace(';', '\n'));

                    break;
                case 2:
                    break;
            }
        }
    }
}
