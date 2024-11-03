namespace User.Application.Command;
public class UpdateTestCommand : BaseGlucometerCommand
{
    public Guid Id { get; set; } = Guid.Empty;
    public ushort Value { get; set; } = 0;
    public DateTime Time { get; set; } = DateTime.MinValue;
    public override bool Validate()
    {
        if (Time == DateTime.MinValue || Value == 0 || Id == Guid.Empty || !base.Validate()) return false;
        return true;
    }
}