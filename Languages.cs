using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableAppsUnpacker
{
    public static class Languages
    {
        public static string lang = CultureInfo.CurrentCulture.Name.ToString();
        public static string Lang(string text)
        {
            if (lang.StartsWith("ru-")) return Russian[text];
            else return English[text];
        }
        static readonly Dictionary<string, string> Russian = new()
        {
            ["SelectPath"] = "Нажми сюда чтобы выберать путь:",
            ["SelectPathPojalusta"] = "Ну путь то выбери",
            ["Unpacked"] = "Распаковано!",
            ["Unpack"] = "Распаковать",
            ["AlreadyUnpacking"] = "Сейчас распаковывается: ",
            ["AllProgress"] = "Всего прогресса: ",
        };
        static readonly Dictionary<string, string> English = new()
        {
            ["SelectPath"] = "Press there to select path:",
            ["SelectPathPojalusta"] = "You forgot to point the path",
            ["Unpacked"] = "Unpacked!",
            ["Unpack"] = "Unpack",
            ["AlreadyUnpacking"] = "Already unpacking: ",
            ["AllProgress"] = "All progress: ",
        };
    }
}
