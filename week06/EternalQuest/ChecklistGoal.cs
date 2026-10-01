public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string name, string description, int points, int amountCompleted, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent() 
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            if (_amountCompleted == _target)
            {
                return Points + _bonus;
            }
            return Points;
        }
        return 0;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        string statusSymbol = IsComplete() ? "X" : " ";
        return $"[{statusSymbol}] {ShortName} ({Description}) — Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{ShortName},{Description},{Points},{_amountCompleted},{_target},{_bonus}";
    }
}
