using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ThTest.Models.Helpers
{
    public class PathProvider : IPathProvider
    {
        protected IHostingEnvironment _env;

        public PathProvider(IHostingEnvironment env)
        {
            this._env = env;
        }

        public string MapPath(params string[] paths)
        {
            return Path.Combine(this._env.WebRootPath, Path.Combine(paths));
        }
    }
}
