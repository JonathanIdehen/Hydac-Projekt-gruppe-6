using Hydac_Gruppe_6;

namespace HydacTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
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
            Assert.AreEqual($"Navn på mødet: Hans' Meeting\nDato for mødet: 24.01.2024 14.30.00\nMødets varighed: 02:00:00\nNavn på mødets ansvarlige: Hans Hansen\nMødelokalets navn: lokale1", meetingToBeShown.ShowMeeting());
        }
    }
}
