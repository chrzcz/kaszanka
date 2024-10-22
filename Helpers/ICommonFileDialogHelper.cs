namespace Kaszanka.Helpers
{
    public interface ICommonFileDialogHelper
    {
        public string GetSaveFilePath(string defaultFileName = "collection");
        public string GetReadFilePath();
    }
}
