namespace PlayersGuide.Notes.Helpers.Cloning;

public class Hero
{
    public int Health { get; set; } = 100;
    public Armor MyArmor { get; set; } = new Armor();

    // Built-in shallow clone
    public Hero CreateShallowClone()
    {
        return (Hero)this.MemberwiseClone();
    }

    // Manual deep clone
    public Hero CreateDeepClone()
    {
        var newHero = new Hero
        {
            Health = this.Health,

            // Deep clone the Armor
            MyArmor = new Armor()
            {
                Durability = this.MyArmor.Durability
            }
        };

        return newHero;
    }
}
