﻿using HarmonyLib;
using RimWorld;
using UnityEngine;

namespace AutoPriorities.HarmonyPatches
{
    [HarmonyPatch(typeof(MainTabWindow_Work), nameof(MainTabWindow_Work.DoWindowContents))]
    public static class WorkTab_AddButtonToOpenAutoPrioritiesWindow
    {
        private static AutoPriorities_Dialog _window;

        static WorkTab_AddButtonToOpenAutoPrioritiesWindow()
        {
            _window = new AutoPriorities_Dialog();
        }

        private static void Postfix(MainTabWindow_Work __instance, Rect rect)
        {
            var button = new Rect(rect.x + 160, rect.y + 5, 25, 25);

            var col = Color.white;

            if (Verse.Widgets.ButtonImage(button, Core.Resources._autoPrioritiesButtonIcon, col, col * 0.9f))
            {
                if (!_window.IsOpen)
                {
                    Verse.Find.WindowStack.Add(_window);
                }
                else
                {
                    _window.Close();
                }
            }
        }
    }
}