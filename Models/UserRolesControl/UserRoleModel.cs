namespace AirBNB.Models.UserRolesControl
{
    public class UserRoleModel
    {
        public string UserId { get; set; }
        public string UserName{ get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
