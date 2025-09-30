using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac_Gruppe_6
{
    internal class Meeting
    {
        private string name;
        private DateTime date;
        private TimeSpan meetingDuration;
        private string responsibleEmployee;
        //private string[] attendingGuests;
        private Room meetingRoom;

        public Meeting(string name, DateTime date, string responsibleEmployee, Room meetingRoom) 
        {
            this.name = name;
            this.date = date;
            this.responsibleEmployee = responsibleEmployee;
            meetingDuration = TimeSpan.FromHours(2);
            this.meetingRoom = meetingRoom;
        }

        public void ShowMeeting()
        {
            Console.Clear();
            Console.WriteLine("Møde med følgende info er nu booket");
            Console.WriteLine($"Navn på mødet: {name}");
            Console.WriteLine($"Dato for mødet: {date}");
            Console.WriteLine($"Mødets varighed: {meetingDuration}");
            Console.WriteLine($"Navn på mødets ansvarlige: {responsibleEmployee}");
            //Console.WriteLine(attendingGuests);
            Console.WriteLine($"Mødelokalets navn: {meetingRoom.RoomName}");
        }
    }
    
}
