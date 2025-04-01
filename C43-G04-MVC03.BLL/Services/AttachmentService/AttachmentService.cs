namespace C43_G04_MVC03.BLL.Services.AttachmentService;

public class AttachmentService : IAttachmentService
{
    private List<string> _allowedExtensions = [".png", ".jpg", ".jpeg"];

    private const int MaxSize = 2_097_152;

    // Max Size
    public string? Upload(IFormFile file, string folderName)
    {
        // 1. Check extension
        var extension = Path.GetExtension(file.FileName);
        if (!_allowedExtensions.Contains(extension)) return null;
        // 2. Check Size
        if (file.Length > MaxSize) return null;

        // 3. Get Located Folder Path
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" , "Files", folderName);
        
        // 4. Make the Attachment Name Unique =>  GUID

        var fileName = $"{Guid.NewGuid()}{extension}";
        
        // 5. Get File Path
        var filePath = Path.Combine(folderPath, fileName);
        
        // 6. Create File Stream to be used for Copying {Unmanaged resource}
        using var stream = new FileStream(filePath, FileMode.Create);
        
        // 7. Use file stream to copy the file
        file.CopyTo(stream);
        
        // 8. Return file name to save in DB
        return fileName;
        
    }

    public bool Delete(string fileName)
    {
        if(!File.Exists(fileName)) return false;
        File.Delete(fileName);
        return true;
    }
}