using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hydac_Gruppe_6
{
    public class Meeting
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
            //string[] attendingGuests;
            this.meetingRoom = meetingRoom;
        }

        public string ShowMeeting()
        {
            CultureInfo dansk = new CultureInfo("da-DK");

            string meetingContents = $"Navn på mødet: {name};Dato for mødet: {date.ToString(dansk)};Mødets varighed: {meetingDuration};Navn på mødets ansvarlige: {responsibleEmployee};Mødelokalets navn: {meetingRoom.RoomName}";
            string[] meetingParts = meetingContents.Split(';');
            string meetingComplete;

            meetingComplete = string.Join('\n', meetingParts);

            return meetingComplete;
        }
    }
    
}
