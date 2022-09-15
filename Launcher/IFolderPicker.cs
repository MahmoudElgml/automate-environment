namespace Launcher
{
    public interface IFolderPicker
    {
        Task<string> PickFolder();
    }
}
