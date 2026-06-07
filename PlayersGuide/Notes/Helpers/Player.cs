namespace PlayersGuide.Notes.Helpers;

public class Player : Entity
{
    public string Name { get; set; }

    // Error: the compiler says: "How do I build the Entity part? I need an id!
    //public Player(string name)
    //{
    //    Name = name;
    //}

    // Solution: we need to call the base constructor and provide an id.
    public Player(int id, string name) : base(id)
    {
        Name = name;
    }

    // Note: the code inside the base (id) constructor executes completely before the code inside the Player constructor starts
}
