public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return Points;
        }
        return 0;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDetailsString()
    {
        string statusSymbol = _isComplete ? "X" : " ";
        return $"[{statusSymbol}] {ShortName} ({Description}) ";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{ShortName},{Description},{Points},{_isComplete}";
    }
}
