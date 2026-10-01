public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int penaltyPoints) 
        : base(name, description, penaltyPoints) { }

    public override int RecordEvent()
    {
        return -Points;
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return $"[!] {ShortName} ({Description}) — Bad Habit (Penalty: -{Points} pts)";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{ShortName},{Description},{Points}";
    }
}
