using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyScheduleApp.Forms
{
    internal class ValidateUserCase
    {
        public static string? ValidateUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return "ユーザー名を入力してください。";
            }

            userName = userName.Trim();

            if (userName.Length < 4 || userName.Length > 20)
            {
                return "ユーザー名は4〜20文字で入力してください。";
            }

            /*if (!Regex.IsMatch(userName, @"^[a-zA-Z0-9_-]+$"))
            {
                return "ユーザー名は英数字と記号（_、-）のみ使用できます。";
            }*/

            return null;
        }

        public static string? ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return "パスワードを入力してください。";
            }

            password = password.Trim();

            if (password.Length < 2 || password.Length > 32)
            {
                return "パスワードは2〜32文字で入力してください。";
            }


            /*if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$"))
            {
                return "パスワードは英大文字・小文字・数字を含めてください。";
            }*/

            return null;
        }

        public static string? ValidateFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return "氏名を入力してください。";
            }

            fullName = fullName.Trim();

            if (fullName.Length > 50)
            {
                return "氏名は50文字以内で入力してください。";
            }

            if (!Regex.IsMatch(fullName, @"^[ぁ-んァ-ン一-龥a-zA-Zー々ヵヶ\s]+$"))
            {
                return "氏名に使用できない文字が含まれています。";
            }

            return null;
        }

        public static bool ValidateAll(string userName, string password, string fullName, out string? userNameError, out string? passwordError, out string? fullNameError)
        {
            userNameError = ValidateUserName(userName);
            passwordError = ValidatePassword(password);
            fullNameError = ValidateFullName(fullName);

            return userNameError == null && passwordError == null && fullNameError == null;

        }
    }
}
