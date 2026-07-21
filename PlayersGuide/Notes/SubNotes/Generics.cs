using PlayersGuide.Notes.SubNotes.GenericsHelpers;
using PlayersGuide.Notes.SubNotes.GenericsHelpers.MultipleGenericConstraints;
using PlayersGuide.Notes.SubNotes.GenericsHelpers.NakedTypeConstraints;
using PlayersGuide.Notes.SubNotes.GenericsHelpers.NotNullConstraint;
using PlayersGuide.Notes.SubNotes.GenericsHelpers.StaticMembersArePerEnclosedType;
using PlayersGuide.Notes.SubNotes.GenericsHelpers.UnmanagedGenericConstraint;
using System.Collections;

namespace PlayersGuide.Notes.SubNotes;

public static class Generics
{
    public static void Show()
    {
        Console.WriteLine("Generics:");

        var customNumbersList = new CustomGenericList<int>();
        customNumbersList.Add(1);
        customNumbersList.Add(2);

        // Multiple generic type parameters
        var genericPair = new GenericPair<int, string>(5, "Hello");

        // Generic method
        var words = GenericRepeater.Repeat("Hello", 3);

        // Generic type constraints
        var myConstrainedList = new ConstraitedList<GameObject>();
        var trollEnemy = new Troll()
        {
            ID = 1,
        };
        myConstrainedList.Add(trollEnemy);

        // Constrainting several generic type parameters
        var manager = new LootManager();
        var myPaladin = new Paladin();

        // We pass the Paladin instance, and tell it to generate a LegendarySword
        manager.GrantLoot<Paladin, LegendarySword>(myPaladin);

        // Naked type constraints: we can use the generic type parameter itself as a constraint for another generic type parameter
        var system = new InventorySystem();
        var entityList = new List<Entity>();
        var playerEntity = new NakedTypePlayer();
        var sword = new Sword();

        system.AddToList(entityList, playerEntity);
        // system.AddToList(entityList, sword); Compiler error: Sword does not satisfy the constraint of being an Entity

        // unmanaged generic constraint
        var memSystem = new MemorySystem();
        memSystem.AllocateMemory(5);
        memSystem.AllocateMemory(new Point());
        // memSystem.AllocateMemory("Hello, World!"); -> not a value type so it does not satisfy the unmanaged constraint
        // memSystem.AllocateMemory(new Player()); -> Player is a struct but it contains a reference type field so it does not satisfy the unmanaged constraint
        memSystem.AllocateMemory(new PlayerStats());

        // notnull constraint
        var eventBus = new EventBus();
        // eventBus.Publish<int?>(null); // only warning because notnull is a nullability constraint and not a type-identity constraint
        // eventBus.Publish<string?>(null); // only warning because notnull is a nullability constraint and not a type-identity constraint
        // there's already a notnull constraint on Dictionary
        // var myDictionary = new Dictionary<int?, int>(); // warning
        eventBus.Publish("Player_Joined");
        eventBus.Publish(new PlayerDamagedEvent { Damage = 10 });

        // Variance
        // Converiance
        object xObject = "hello"; // plain: string stands in for object
        IEnumerable<string> eStrings = new List<string>();
        IEnumerable<object> eObjects = eStrings; // covariance: IEnumerable<string> stands in for IEnumerable<object>

        // Contravariance
        Action<object> printAny = o => Console.WriteLine(o);
        Action<string> printStr = printAny; // contravariance: Action<object> stands in for Action<string>

        // Invariance
        //List<string> strings = new() { "a", "b" };
        //List<object> objects = strings;   // ❌ CS0266 — does NOT compile

        // Static members are per-closed-type
        var counter1 = new Counter<int>();
        var counter2 = new Counter<int>();
        var counter3 = new Counter<string>();

        Console.WriteLine(Counter<int>.Count);      // 2
        Console.WriteLine(Counter<string>.Count);   // 1

        ArrayList list = new ArrayList();
        list.Add(1);
        list.Add("hello");

        // int asd = (int)list[1];
    }
}
