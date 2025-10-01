using Hydac_Gruppe_6;

namespace HydacTest
{
    [TestClass]
    public sealed class Test1
    {
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
            Assert.AreEqual("Hans' Meeting;1/24/2024 2:30:00 PM;02:00:00;Hans Hansen;lokale1;1", meetingToBeShown.GetMeetingContents());
        }

        [TestMethod]
        public void TestPersistence()
        {
            //arrange
            MeetingCatalogue tempForMeetings = new MeetingCatalogue();
            Meeting[] savedMeetings;

            string meetingName = "Hans' Meeting";
            DateTime meetingTime = DateTime.Parse("Jan 24, 2024, 14:30");
            TimeSpan meetingDuration = TimeSpan.FromHours(2);
            string meetingEmployee = "Hans Hansen";
            Room meetingRoom = new Room("lokale1", 1);

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
            //test doesnt exist therefore 'temporary catalogue' is set to have one slot
            tempForMeetings.ReadMeetingsFromFile("testMeetings.txt");

            savedMeetings = tempForMeetings.SavedMeetings;
            savedMeetings[0] = meeting1;

            //new meeting is added to the 'temporary catalogue'
            tempForMeetings.SavedMeetings = savedMeetings;

            //temporary catalogue is written to the file path
            tempForMeetings.WriteMeetingsToFile("testMeetings.txt");

            //temporary catalogue is overwritten with latest saved meetings (by reading from file)
            //the temporary catalogue will now have two slots total, index 0 occupied by the saved meeting and index 1 being empty
            tempForMeetings.ReadMeetingsFromFile("testMeetings.txt");

            savedMeetings = tempForMeetings.SavedMeetings;
            savedMeetings[1] = meeting2;

            //new meeting is added to the 'temporary catalogue'
            tempForMeetings.SavedMeetings = savedMeetings;

            //temporary catalogue is written to the file path
            tempForMeetings.WriteMeetingsToFile("testMeetings.txt");

            //temporary catalogue is overwritten with latest saved meetings (by reading from file)
            //the temporary catalogue will now have three slots total, index 0 and 2 occupied by the saved meeting and index 3 being empty
            tempForMeetings.ReadMeetingsFromFile("testMeetings.txt");

            savedMeetings = tempForMeetings.SavedMeetings;

            //assert
            Assert.AreEqual("BIGMeeting;1/14/2014 3:20:00 PM;02:00:00;Jens Jensen;storelokale;4", savedMeetings[1].GetMeetingContents());
        }
    }
}
