namespace C43_G04_MVC03.BLL.Services.AttachmentService;

public interface IAttachmentService
{
    bool Delete(string fileName);    
    
    string? Upload(IFormFile file,string folderName);    
}
