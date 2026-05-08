using MelonLoader;
using UnityEngine;

namespace ParryParryParryParryParryParryParryParryParryParryParry
{
    public class ParryParryParryParryParryParryParryParryParryParryParry : MelonMod
    {
        internal static ParryParryParryParryParryParryParryParryParryParryParry instance;
        internal static MelonLogger.Instance Log => instance.LoggerInstance;

        public override void OnInitializeMelon()
        {
            instance = this;

            // Register the settings
            Settings.Register();

            NeonLite.Modules.Anticheat.Register(MelonAssembly);
            // Load all modules tagged with the IModule interface
            NeonLite.NeonLite.LoadModules(MelonAssembly);
        }
        internal static class Settings
        {
            public const string Px11Holder = "ParryParryParryParryParryParryParryParryParryParryParry";

            public static void Register()
            {
                NeonLite.Settings.AddHolder(Px11Holder);
            }
        }
    }
}
