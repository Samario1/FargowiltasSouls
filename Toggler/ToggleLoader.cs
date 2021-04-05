﻿using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace FargowiltasSouls.Toggler
{
    public static class ToggleLoader
    {
        public static Dictionary<string, bool> LoadedRawToggles;
        public static Dictionary<string, Toggle> LoadedToggles;
        public static List<int> HeaderToggles;
        public static Dictionary<string, (string name, int item)> LoadedHeaders;

        public static void Load()
        {
            LoadedRawToggles = new Dictionary<string, bool>();
            LoadedToggles = new Dictionary<string, Toggle>();
            HeaderToggles = new List<int>();
            LoadedHeaders = new Dictionary<string, (string name, int item)>();
            LoadTogglesFromAssembly(Fargowiltas.Instance.Code);
        }

        public static void LoadTogglesFromAssembly(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();
            List<ToggleCollection> collections = new List<ToggleCollection>();

            for (int i = 0; i < types.Length; i++)
            {
                Type type = types[i];
                if (typeof(ToggleCollection).IsAssignableFrom(type) && !type.IsAbstract)
                {
                    ToggleCollection toggles = (ToggleCollection)Activator.CreateInstance(type);
                    collections.Add(toggles);
                }
            }

            IEnumerable<ToggleCollection> orderedCollections = collections.OrderBy((collection) => collection.Priority);
            Fargowiltas.Instance.Logger.Info($"ToggleCollections found: {orderedCollections.Count()}");

            foreach (ToggleCollection collection in orderedCollections)
            {
                List<Toggle> toggleCollectionChildren = collection.Load(LoadedToggles.Count - 1);

                foreach (Toggle toggle in toggleCollectionChildren)
                {
                    RegisterToggle(toggle);
                }
            }
        }

        public static void Unload()
        {
            if (LoadedRawToggles != null)
                LoadedRawToggles.Clear();
            if (LoadedToggles != null)
                LoadedToggles.Clear();
            if (HeaderToggles != null)
                HeaderToggles.Clear();
            if (LoadedHeaders != null)
                LoadedHeaders.Clear();
        }

        public static void RegisterToggle(Toggle toggle)
        {
            if (LoadedToggles.ContainsKey(toggle.InternalName) || LoadedRawToggles.ContainsKey(toggle.InternalName)) throw new Exception("Toggle with internal name " + toggle.InternalName + " is already registered");

            LoadedToggles.Add(toggle.InternalName, toggle);
            LoadedRawToggles.Add(toggle.InternalName, toggle.ToggleBool);

            if (LoadedHeaders.ContainsKey(toggle.InternalName))
                HeaderToggles.Add(LoadedToggles.Values.ToList().FindIndex((t) => t.InternalName == toggle.InternalName));
        }
    }
}
