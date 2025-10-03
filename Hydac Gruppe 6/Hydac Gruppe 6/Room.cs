using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac_Gruppe_6
{
    public class Room
    {
        //backing fields
        private string roomName;
        private int roomNumber;

        //properties
        public string RoomName { get { return roomName; } }
        public int RoomNumber { get { return roomNumber; } }

        //constructors
        public Room(string roomName, int roomNumber)
        {
            this.roomName = roomName;
            this.roomNumber = roomNumber;
        }
    }
}
