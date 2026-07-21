namespace PlayersGuide.Notes.SubNotes.GenericsHelpers.NotNullConstraint;

public class EventBus
{
    public void Publish<TEvent>(TEvent eventMessage) where TEvent : notnull
    {
        string eventName = eventMessage.GetType().Name;
        Console.WriteLine($"[EventBus] Routing event {eventName} = {eventMessage}");
    }
}
