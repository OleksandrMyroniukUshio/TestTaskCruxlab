using System.Text.RegularExpressions;

namespace PasswordCheckerBackend.Services.PasswordValidateService
{
    public class PasswordValidatorService : IPasswordValidatorService
    {
        public int CountValidPasswords(string content)
        {
            var lines = content.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            return lines.Count(IsValidPassword);
        }

        private bool IsValidPassword(string line)
        {
            var match = Regex.Match(line, @"^(\w) (\d+)-(\d+): (.+)$");
            if (!match.Success)
                return false;

            char charToCheck = match.Groups[1].Value[0];
            int.TryParse(match.Groups[2].Value, out int min);
            int.TryParse(match.Groups[3].Value, out int max);
            if (min > max)
                return false;

            string password = match.Groups[4].Value;

            int charCount = password.Count(c => c == charToCheck);

            return charCount >= min && charCount <= max;
        }
    }
}
