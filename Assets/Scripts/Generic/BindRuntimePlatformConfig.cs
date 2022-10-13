using System;
using System.Collections.Generic;
using UnityEngine;

namespace Generic
{
	public static class BindRuntimePlatformConfig
    {
        private static Dictionary<GenericRuntimePlatform, List<RuntimePlatform>> binds;

        public static Dictionary<GenericRuntimePlatform, List<RuntimePlatform>> GetBinds()
		{
            if (binds != null) return binds;

            Instance();

            return binds;
        }

        public static GenericRuntimePlatform GetGenericRuntimePlatform()
		{
            if (binds == null) Instance();

            foreach (var bind in binds)
			{
                foreach (var platform in bind.Value)
                {
                    if ( platform == Application.platform)
					{
                        return bind.Key;
                    }
                }
            }

            new Exception("Unknown GenericRuntimePlatform -> " + Application.platform);
            return GenericRuntimePlatform.Unknown;
        }

        private static void Instance()
		{
            binds = new Dictionary<GenericRuntimePlatform, List<RuntimePlatform>>();

            List<RuntimePlatform> Editor = new List<RuntimePlatform>();
            Editor.Add(RuntimePlatform.WindowsEditor);
            Editor.Add(RuntimePlatform.OSXEditor);
            Editor.Add(RuntimePlatform.LinuxEditor);

            List<RuntimePlatform> PC = new List<RuntimePlatform>();
            PC.Add(RuntimePlatform.WindowsPlayer);
            PC.Add(RuntimePlatform.OSXPlayer);
            PC.Add(RuntimePlatform.LinuxPlayer);

            List<RuntimePlatform> Phone = new List<RuntimePlatform>();
            Phone.Add(RuntimePlatform.Android);
            Phone.Add(RuntimePlatform.IPhonePlayer);
            Phone.Add(RuntimePlatform.Lumin);
            //Phone.Add(RuntimePlatform.BlackBerryPlayer);

            List<RuntimePlatform> Web = new List<RuntimePlatform>();
            Web.Add(RuntimePlatform.WebGLPlayer);

            List<RuntimePlatform> Console = new List<RuntimePlatform>();
            //Console.Add(RuntimePlatform.PS3);
            Console.Add(RuntimePlatform.PS4);
            Console.Add(RuntimePlatform.PS5);
            //Console.Add(RuntimePlatform.XBOX360);
            Console.Add(RuntimePlatform.XboxOne);

            List<RuntimePlatform> PortConsole = new List<RuntimePlatform>();
            PortConsole.Add(RuntimePlatform.Switch);
            PortConsole.Add(RuntimePlatform.Stadia);
            //PortConsole.Add(RuntimePlatform.PSM);
            //PortConsole.Add(RuntimePlatform.PSP2);

            List<RuntimePlatform> TV = new List<RuntimePlatform>();
            TV.Add(RuntimePlatform.tvOS);
            //TV.Add(RuntimePlatform.SamsungTVPlayer);

            List<RuntimePlatform> VR = new List<RuntimePlatform>();
            VR.Add(RuntimePlatform.Android);

            binds.Add(GenericRuntimePlatform.Editor, Editor);
            binds.Add(GenericRuntimePlatform.PC, PC);
            binds.Add(GenericRuntimePlatform.Phone, Phone);
            binds.Add(GenericRuntimePlatform.Console, Console);
            binds.Add(GenericRuntimePlatform.PortConsole, PortConsole);
            binds.Add(GenericRuntimePlatform.TV, TV);
            binds.Add(GenericRuntimePlatform.VR, VR);
        }
    }
}
