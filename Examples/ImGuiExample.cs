﻿namespace Examples
{
    using System.Drawing;

    using Rage;
    using Rage.Attributes;

    using RAGENativeUI;
    using RAGENativeUI.ImGui;
    using RAGENativeUI.Rendering;

    internal static class ImGuiExample
    {
        [ConsoleCommand(Name = "ImGuiExample", Description = "Example showing the ImGui.Gui class.")]
        private static void Command()
        {
            RectangleF windowRect1 = new RectangleF(10, 10, 350, 585);
            RectangleF windowRect2 = new RectangleF(900, 10, 650, 650);
            RectangleF windowRect3 = new RectangleF(5, 50, 320, 320);
            RectangleF windowRect4 = new RectangleF(5, 25, 180, 180);
            float slider1Value = 5.0f;
            float slider2Value = 50.0f;
            int slider3Value = 100;
            bool toggleValue = false;
            Gui.Do += () =>
            {
                Gui.Mouse(); // enable mouse

                // main window
                windowRect1 = Gui.BeginWindow(windowRect1, "Test");

                Gui.Label(new RectangleF(5, 5, 100, 40), "Label");

                if (Gui.Button(new RectangleF(5, 50, 125, 50), "Button"))
                {
                    Game.DisplayNotification("Button Pressed!");
                }

                Gui.Label(new RectangleF(5, 110, 300, 25), $"{slider1Value.ToString("0.0000")}");
                slider1Value = Gui.HorizontalSlider(new RectangleF(5, 145, 320, 30), slider1Value, 0.0f, 10.0f);

                Gui.Label(new RectangleF(5, 180, 300, 25), $"{slider2Value.ToString("0.0000")}");
                slider2Value = Gui.VerticalSlider(new RectangleF(5, 215, 30, 320), slider2Value, -1000.0f, 1000.0f);

                Gui.Label(new RectangleF(110, 225, 200, 30), $"{slider3Value}");
                slider3Value = Gui.HorizontalSlider(new RectangleF(110, 260, 160, 20), slider3Value, 0, 255);

                toggleValue = Gui.Toggle(new RectangleF(180, 200, 140, 25), $"Toggle: {toggleValue}", toggleValue);

                Gui.EndWindow();


                // nested windows
                windowRect2 = Gui.BeginWindow(windowRect2, "Test 2");

                if (Gui.Button(new RectangleF(5, 5, 120, 35), "Button 1"))
                {
                    Game.DisplayNotification("First button pressed from second window!");
                }

                windowRect3 = Gui.BeginWindow(windowRect3, "Winception");
                if (Gui.Button(new RectangleF(5, 45, 120, 35), "Button 2"))
                {
                    Game.DisplayNotification("Second button pressed from second window!");
                }

                windowRect4 = Gui.BeginWindow(windowRect4, "Winception");
                if (Gui.Button(new RectangleF(5, 45, 120, 35), "Button 3"))
                {
                    Game.DisplayNotification("Third button pressed from second window!");
                }

                Gui.EndWindow();
                Gui.EndWindow();
                Gui.EndWindow();


                // fixed window
                Gui.BeginWindow(new RectangleF(Game.Resolution.Width - 175, Game.Resolution.Height - 175, 150, 150), "Fixed Window");

                if(Gui.Button(new RectangleF(5f, 5f, 140f, 110f), "A button"))
                {
                    Game.DisplayNotification("Button pressed from fixed window!");
                }

                Gui.EndWindow();

                // without window
                Gui.Label(new RectangleF(5f, 5f, 300f, 70f), "Label without window", 18.5f);
                Gui.Button(new RectangleF(5f, 75f, 200f, 80f), "Button without window");
            };
        }
    }
}
