using Hydac_Gruppe_6;

namespace HydacTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestShowMeeting()
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
            tempForMeetings.DeleteMeetingsInFile("testMeetings.txt");

            //act
            //assert
        }
    }
}
