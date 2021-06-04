using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class ChangePasswordDto : IDto
    {
        public string Email { get; set; }
        public string OldPassWord { get; set; }
        public string NewPassword { get; set; }
    }
}