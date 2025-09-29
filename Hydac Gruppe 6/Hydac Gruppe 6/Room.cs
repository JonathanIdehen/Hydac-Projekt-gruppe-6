using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac_Gruppe_6
{
    internal class Room
    {
        private string roomName;
        private int roomNumber;

        public string RoomName { get; }

        public int RoomNumber { get; }

        public Room(string roomName, int roomNumber)
        {
            this.roomName = roomName;
            this.roomNumber = roomNumber;
        }
    }
}
