using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELib.BLL
{
    public interface IEntity
    {
        int MaSo { get; set; }
        object[] GetInsertUpdateValues();
    }
}
