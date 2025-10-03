using Hydac_Gruppe_6;

namespace HydacTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestInitialize]
        public void Init()
        {
            //this program is tested in a danish environment and therefore at least works in danish environments
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("da-DK");
        }

        [TestMethod]
        public void TestGetMeetingContents()
        {
            //arrange
            string meetingName = "Hans' Meeting";
            DateTime meetingTime = DateTime.Parse("Jan 24, 2024, 14:30");
            TimeSpan meetingDuration = TimeSpan.FromHours(2);
            string meetingEmployee = "Hans Hansen";
            Room meetingRoom = new Room("lokale1", 1);

            //act
            Meeting meetingToBeShown = new Meeting(meetingName, meetingTime, meetingEmployee, meetingRoom);

            //assert
            Assert.AreEqual("Hans' Meeting;24.01.2024 14.30.00;02:00:00;Hans Hansen;lokale1;1", meetingToBeShown.GetMeetingContents());
        }

        [TestMethod]
        public void TestPersistence()
        {
            //arrange
            //make 'temporary catalogue'
            MeetingCatalogue tempForMeetings = new MeetingCatalogue();

            //make current meeting array
            Meeting[] savedMeetings;

            //meeting1 contents 
            string meetingName = "Hans' Meeting";
            DateTime meetingTime = DateTime.Parse("Jan 24, 2024, 14:30");
            TimeSpan meetingDuration = TimeSpan.FromHours(2);
            string meetingEmployee = "Hans Hansen";
            Room meetingRoom = new Room("lokale1", 1);

            //meeting2 contents
            string meetingName2 = "BIGMeeting";
            DateTime meetingTime2 = DateTime.Parse("Jan 14, 2014, 15:20");
            TimeSpan meetingDuration2 = TimeSpan.FromHours(2);
            string meetingEmployee2 = "Jens Jensen";
            Room meetingRoom2 = new Room("storelokale", 4);

            Meeting meeting1 = new Meeting(meetingName, meetingTime, meetingEmployee, meetingRoom);
            Meeting meeting2 = new Meeting(meetingName2, meetingTime2, meetingEmployee2, meetingRoom2);

            //delete testfile
            tempForMeetings.DeleteMeetingsFile("testMeetings.txt");

            //act
            //test doesnt exist therefore 'temporary catalogue' Meeting array is set to have one slot during the method call ReadMeetingsFromFile()
            tempForMeetings.ReadMeetingsFromFile("testMeetings.txt");

            //current meeting array is updated to be what was read to the temporary catalogue
            savedMeetings = tempForMeetings.SavedMeetings;

            //meeting1 is added to 'current meeting array'
            savedMeetings[0] = meeting1;

            //current meeting array is added to the 'temporary catalogue'
            tempForMeetings.SavedMeetings = savedMeetings;

            //temporary catalogue is written to the file path
            tempForMeetings.WriteMeetingsToFile("testMeetings.txt");

            //temporary catalogue is overwritten with latest saved meetings (by reading from file)
            //the temporary catalogue will now have two slots total, index 0 occupied by the saved meeting and index 1 being empty
            tempForMeetings.ReadMeetingsFromFile("testMeetings.txt");

            //current meeting array is updated to be what was read to the temporary catalogue
            savedMeetings = tempForMeetings.SavedMeetings;

            //meeting2 is added to 'current meeting array'
            savedMeetings[1] = meeting2;

            //current meeting array is added to the 'temporary catalogue'
            tempForMeetings.SavedMeetings = savedMeetings;

            //temporary catalogue is written to the file path
            tempForMeetings.WriteMeetingsToFile("testMeetings.txt");

            //temporary catalogue is overwritten with latest saved meetings (by reading from file)
            //the temporary catalogue will now have three slots total, index 0 and 1 occupied by the saved meeting and index 2 being empty
            tempForMeetings.ReadMeetingsFromFile("testMeetings.txt");

            //current meeting array is updated to be what was read to the temporary catalogue
            savedMeetings = tempForMeetings.SavedMeetings;

            //assert
            Assert.AreEqual("BIGMeeting;14.01.2014 15.20.00;02:00:00;Jens Jensen;storelokale;4", savedMeetings[1].GetMeetingContents());
        }
    }
}
