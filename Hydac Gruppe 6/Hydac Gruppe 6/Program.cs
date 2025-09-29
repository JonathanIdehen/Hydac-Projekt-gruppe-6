namespace Hydac_Gruppe_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userType;
            Room[] roomArray = new Room[4];
            //roomArray[0] = new Room("asd", 1);
            roomArray[0] = new Room("asd", 1);
            roomArray[1] = new Room("asd", 2);
            roomArray[2] = new Room("asd", 3);
            roomArray[3] = new Room("asd", 4);


            Console.WriteLine("Velkommen til Hydac!");
            Console.WriteLine("Hvis du er medarbejder, skriv 1. Hvis du er gæst, skriv 2");

            userType = int.Parse(Console.ReadLine());

            switch (userType)
            {
                case 1:
                    //user input for meeting constructor parametre, og array af meetings kommer også med. 
                    //kald meeting constructor, derefter "gem" det instantierede møde i et array for at repræsentere persistens
                    break;
                case 2:
                    break;
            }
        }
    }
}
