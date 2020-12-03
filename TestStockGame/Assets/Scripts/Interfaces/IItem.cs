using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface IItem
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string ImageName { get; set; }
    }
}
