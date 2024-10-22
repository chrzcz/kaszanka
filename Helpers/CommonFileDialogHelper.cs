using Microsoft.Win32;

namespace Kaszanka.Helpers
{
    internal class CommonFileDialogHelper : ICommonFileDialogHelper
    {
        public string GetReadFilePath()
        {
            var dialog = new OpenFileDialog
            {
                DefaultExt = ".json",
                Filter = "Collection documents|*.json"
            };
            return ShowDialog(dialog);
        }

        public string GetSaveFilePath(string defaultFileName)
        {
            var dialog = new SaveFileDialog
            {
                FileName = defaultFileName,
                DefaultExt = ".json",
                Filter = "Collection documents|*.json"
            };
            return ShowDialog(dialog);
        }

        private static string ShowDialog(FileDialog dialog)
        {
            bool? result = dialog.ShowDialog();
            if (result is not null && result.Value)
            {
                return dialog.FileName;
            }

            return string.Empty;
        }
    }
}
