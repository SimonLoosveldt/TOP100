using System.Collections.Generic;
using System.Reflection;
using TopHundred.Core.Controllers;

namespace TopHundred.Views
{
    public partial class App
    {

        public List<Assembly> _extraAssemblies = new List<Assembly>
        {
            typeof(InputController).Assembly,
            typeof(UserController).Assembly
        };

    }
}
