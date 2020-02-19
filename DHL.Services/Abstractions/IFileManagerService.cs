namespace DHL.Services.Abstractions
{
    public interface IFileManagerService
    {
        string Move(string filePath);

        void SaveLabel(string labelName, string outputDirectory, byte[] fileBytes);
    }
}
