namespace HRM.Common
{
    public interface ISoftDeleteable
    {
        bool IsDeleted { get; set; }
    }
}
