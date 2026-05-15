namespace PlayersGuide.Level24.Catacombs;

public class Door
{
    private string _passcode;

    public DoorStatus DoorStatus { get; private set; }

    public Door(string passcode)
    {
        _passcode = passcode;
        DoorStatus = DoorStatus.Locked;
    }

    public bool TryChangePasscode(string currentPasscode, string newPasscode)
    {
        if (currentPasscode != _passcode)
        {
            Console.WriteLine("Incorrect passcode. Access denied.");
            return false;
        }

        _passcode = newPasscode;
        Console.WriteLine("Passcode changed successfully.");

        return true;
    }

    public void Open()
    {
        if (DoorStatus != DoorStatus.Closed)
        {
            Console.WriteLine("Invalid door status. Can't open.");
            return;
        }

        Console.WriteLine("You open the door.");
        DoorStatus = DoorStatus.Open;
    }

    public void Close()
    {
        if (DoorStatus != DoorStatus.Open)
        {
            Console.WriteLine("Invalid door status. Can't close.");
            return;
        }

        Console.WriteLine("You close the door.");
        DoorStatus = DoorStatus.Closed;
    }

    public void Lock()
    {
        if (DoorStatus != DoorStatus.Closed)
        {
            Console.WriteLine("Invalid door status. Can't lock.");
            return;
        }

        Console.WriteLine("You lock the door.");
        DoorStatus = DoorStatus.Locked;
    }

    public void Unlock()
    {
        if (DoorStatus != DoorStatus.Locked)
        {
            Console.WriteLine("Invalid door status. Can't unlock.");
            return;
        }

        Console.WriteLine("Enter the passcode to unlock the door:");
        string passcode = Console.ReadLine()!;

        if (passcode != _passcode)
        {
            Console.WriteLine("Incorrect passcode. Access denied.");
            return;
        }

        Console.WriteLine("You unlock the door.");
        DoorStatus = DoorStatus.Closed;
    }
}
