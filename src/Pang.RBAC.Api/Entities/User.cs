namespace Pang.RBAC.Api.Entities
{
    public class User: Entity
    {
        public string Username{get; set;}
        public string Password{get; set;}
        public bool IsSuper{get; set;} = false;
    }
}