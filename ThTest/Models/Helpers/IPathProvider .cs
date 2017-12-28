using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThTest.Models.Helpers
{
    public interface IPathProvider
    {
        string MapPath(params string[] path);
    }
}
