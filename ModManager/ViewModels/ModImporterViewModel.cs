﻿using System.IO;
using System.Linq;

using static ModManager.Properties.Settings;

namespace ModManager.ViewModels
{
    public class ModImporterViewModel
    {
        public string[] Directories { get; set; }
        public ModDataViewModel ModData { get; set; }

        public ModImporterViewModel()
        {
            Directories = Directory.GetDirectories(Default.ModImportPath).Select(x => x.Split(Path.DirectorySeparatorChar).Last()).ToArray();
        }
        public void GetModData(string url) => ModData =  new ModDataViewModel(url);
        public void ModImport(int selectedIndex)
        {
            string dirPath = Path.Combine(Default.ModImportPath, Directories[selectedIndex]);
            ModData.Import(dirPath);
        }
    }
}
