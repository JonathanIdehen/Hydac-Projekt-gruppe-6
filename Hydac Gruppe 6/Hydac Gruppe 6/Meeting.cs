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
        private TimeSpan meetingDuration = TimeSpan.FromHours(2);
        private string responsibleEmployee;
        private string[] attendingGuests;
        private Room meetingRoom;

        public Meeting(string name, DateTime date, string responsibleEmployee, Room[] meetingRooms) 
        {
            this.name = name;
            this.date = date;
            this.responsibleEmployee = responsibleEmployee;

            //vælg rum logik
            foreach(Room element in meetingRooms)
            {
                Console.WriteLine(element.RoomNumber + ". " + element.RoomName);
            }

            //indsæt valgte rum
            this.meetingRoom = ;
        }
    }
    
}
