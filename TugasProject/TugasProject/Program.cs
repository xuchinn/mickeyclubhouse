using System;
using LearnOpenTK.Common;
using OpenTK.Windowing.Desktop;

namespace TugasProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new OpenTK.Mathematics.Vector2i(1920, 1080),
                Title = "Mickey Mouse Clubhouse"
            };

            using (var window = new Window(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }
        }
    }
}