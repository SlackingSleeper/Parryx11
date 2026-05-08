using MelonLoader;
using NeonLite.Modules;
using UnityEngine;

namespace ParryParryParryParryParryParryParryParryParryParryParry.Modules
{
    // This is an example template module that does nothing but print things to log every few seconds.
    // Check NeonLite/Modules/IModule.cs for more information.
    // Make sure to remove the wrapped #if false when you copy this!
    internal class PARRYMODULE : MonoBehaviour, IModule
    {
        // A "true" priority means it'll start before the low priority mods (before the main menu loads.)
        // This uses a holder, so Activate gets called later.
        const bool priority = false;
        static bool active = false;
        static MelonPreferences_Entry<bool> floatYes;
        // This will be called once at the start of the game.
        // All mods will be setup at the same time, no matter their priority.
        static void Setup()
        {
            // This is how you would create a toggle setting using the Settings framework.
            // An empty string as the first argument means it goes into the main category.
            var manyParrySetting = Settings.Add(global::ParryParryParryParryParryParryParryParryParryParryParry.ParryParryParryParryParryParryParryParryParryParryParry.Settings.Px11Holder, "", "PARRRRTY TIME", "ACTIVATE THE PARRYNATOR", "", true);
            active = manyParrySetting.SetupForModule(Activate, static (_, after) => after);
            
            floatYes = Settings.Add(global::ParryParryParryParryParryParryParryParryParryParryParry.ParryParryParryParryParryParryParryParryParryParryParry.Settings.Px11Holder, "", "FLOATINGPARRY", "ENABLE THE FLOATY PARRY", "", false);
        }
        // Activate will be called either at the start of the game or on mod menu setup depending on the priority.
        // It may be called because of a setting, passed with a bool that says whether or not to activate it.
        // Here is where you should handle (un)patching using Patching.TogglePatch and component addition and destruction.
        static void Activate(bool activate)
        {
            Patching.TogglePatch(activate, typeof(FirstPersonDrifter).GetMethod("AddVelocity"), ParryParryParryParryParryParryParryParryParryParryParry, Patching.PatchTarget.Prefix);

            active = activate;
        }
        static bool ParryParryParryParryParryParryParryParryParryParryParry(Vector3 vel,ref Vector3 ___velocity)
        {
            ___velocity += vel;
            return false;
        }
        static void OnLevelLoad(LevelData level)
        {
            if (floatYes.Value)
            {
                var _parryPreventsFalling = Helpers.Field(typeof(FirstPersonDrifter), "_parryPreventsFalling");
                if (RM.drifter != null)
                {
                    _parryPreventsFalling.SetValue(RM.drifter, true);
                }
            }
        }
    }
}