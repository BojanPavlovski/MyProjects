using LibraryManagementSystem.Domain.Domain;

namespace LibraryManagementSystem.DataAccess.Interfaces
{
    public interface IAdminRepository
    {
        public List<Admin> GetAdmin();
        public void Add(Admin entity);

    }
}
