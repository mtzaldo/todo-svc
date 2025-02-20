namespace Todo.Broker.Domain.Boundaries;

public record TodoRequest(string Title, bool Completed);