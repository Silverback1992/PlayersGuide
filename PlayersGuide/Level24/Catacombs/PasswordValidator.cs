namespace PlayersGuide.Level24.Catacombs;

public static class PasswordValidator
{
    public static bool ValidatePassword(string password)
    {
        if (password.Length < 6)
        {
            Console.WriteLine("Password must be at least 6 characters long.");
            return false;
        }

        if (password.Length > 13)
        {
            Console.WriteLine("Password cannot be longer than 13 characters.");
            return false;
        }

        if (!password.Any(char.IsUpper))
        {
            Console.WriteLine("Password must contain at least one uppercase letter.");
            return false;
        }

        if (!password.Any(char.IsLower))
        {
            Console.WriteLine("Password must contain at least one lowercase letter.");
            return false;
        }

        if (!password.Any(char.IsDigit))
        {
            Console.WriteLine("Password must contain at least one digit.");
            return false;
        }

        if (password.Any(c => c == 'T' || c == '&'))
        {
            Console.WriteLine("Password cannot contain 'T' or '&'. By decree of Ingelmar in IT.");
            return false;
        }

        Console.WriteLine("Password is valid.");
        return true;
    }
}
