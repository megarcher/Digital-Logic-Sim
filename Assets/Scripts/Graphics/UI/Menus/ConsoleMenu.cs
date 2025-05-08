using System;
using DLS.Description;
using DLS.Game;
using DLS.Graphics;
using Seb.Vis.UI;
using Seb.Vis;
using UnityEngine;
using UnityEngine.UIElements;
using Seb.Types;

namespace DLS.Graphics
{
    public static class ConsoleMenu
    {
        const float menuWidth = 60;
        const float verticalOffset = 20;


        // shared buffer (populate from your ConsoleChip)
        public static string ConsoleBuffer = string.Empty;

        public static void DrawMenu()
        {

            // Overlay and panel
            DrawSettings.UIThemeDLS theme = DrawSettings.ActiveUITheme;
            MenuHelper.DrawBackgroundOverlay();
            Draw.ID panelID = UI.ReservePanel();

            using (UI.BeginBoundsScope(true))
            {
                // Header
                UI.DrawText("Console Output", theme.FontBold, theme.FontSizeRegular,  new Vector2(0, 0), Anchor.TextCentreLeft, new Color(1, 1, 1, 1));
                // ... your scrollable text field drawing here ...
            }

            Bounds2D menuBounds = UI.GetCurrentBoundsScope();
            MenuHelper.DrawReservedMenuPanel(panelID, menuBounds);

            // Positioning
            Vector2 topLeft = UI.Centre + new Vector2(-menuWidth / 2, verticalOffset);

            // Title
            UI.DrawText("Console", theme.FontBold, theme.FontSizeRegular, topLeft, Anchor.TextCentre, Color.white);

            // Output area
            Vector2 outputPos = topLeft + new Vector2(0, -3);
            Vector2 outputSize = new Vector2(menuWidth, 10);
            UI.DrawPanel(new Bounds2D(outputPos, outputSize), new Color(0.1f, 0.1f, 0.1f));
            UI.DrawText(ConsoleBuffer, theme.FontRegular, theme.FontSizeRegular, outputPos + new Vector2(0.2f, -0.2f), Anchor.TopLeft, Color.white);

            // Close button
            Vector2 buttonPos = outputPos + new Vector2(0, -outputSize.y - 1);
            if (UI.Button("Close", theme.MenuPopupButtonTheme, buttonPos, new Vector2(10, 1.5f), true, false, false, Anchor.TopLeft))
            {
                UIDrawer.SetActiveMenu(UIDrawer.MenuType.None);
            }

            // Draw panel
            MenuHelper.DrawReservedMenuPanel(panelID, menuBounds);
        }

        public static void OnMenuOpened()
        {
            // nothing needed for now, buffer is already populated
        }

        public static void HandleKeyboardShortcuts()
        {
            if (KeyboardShortcuts.ConsoleShortcutTriggered)
            {
                UIDrawer.SetActiveMenu(UIDrawer.MenuType.None);
            }
        }
    }
}
