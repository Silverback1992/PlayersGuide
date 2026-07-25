namespace PlayersGuide.Notes.SubNotes.GenericsHelpers.NotNullConstraint;

public class EventBus
{
    private readonly Dictionary<Type, List<Action<object>>> _subscribers = new();

    public void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : notnull
    {
        var eventType = typeof(TEvent);

        if (!_subscribers.ContainsKey(eventType))
        {
            _subscribers[eventType] = [];
        }

        _subscribers[eventType].Add(e => handler((TEvent)e));
    }

    public void Publish<TEvent>(TEvent eventMessage) where TEvent : notnull
    {
        Type key = eventMessage.GetType();

        if (_subscribers.TryGetValue(key, out var handlers))
        {
            foreach (var handler in handlers)
            {
                handler(eventMessage);
            }

            return;
        }

        Console.WriteLine($"No subscribers for: {key.Name}");
    }
}
