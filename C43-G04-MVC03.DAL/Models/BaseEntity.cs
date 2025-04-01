namespace C43_G04_MVC03.Presentation.DAL.Models;

public class BaseEntity
{
    public int Id { get; set; } // PK
    public bool IsDeleted { get; set; }
    public int CreatedBy { get; set; } // user Id
    public DateTime CreatedOn { get; set; } 
    public int LastModified { get; set; } // user Id
    public DateTime LastModifiedOn { get; set; }
}