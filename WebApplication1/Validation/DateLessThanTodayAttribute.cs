using System.ComponentModel.DataAnnotations;

public class DateLessThanTodayAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null)
            return false;

        if (value is DateOnly date)
        {
            return date < DateOnly.FromDateTime(DateTime.Today);
        }

        return false;
    }

    public override string FormatErrorMessage(string name)
    {
        return $"{name} phải nhỏ hơn ngày hiện tại.";
    }
}
