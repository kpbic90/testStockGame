using System;

namespace Assets.Scripts.Interfaces
{
    public interface IUser
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string AvatarUrl { get; set; }
        int Level { get; set; }
    }
}
