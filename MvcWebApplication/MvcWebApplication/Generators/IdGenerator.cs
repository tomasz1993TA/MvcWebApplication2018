using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace MvcWebApplication.Generators
{
    public class IdGenerator
    {
        public string GetId()
        {
            StringBuilder builder = new StringBuilder();

            Enumerable
               .Range(65, 26)
                    .Select(e => ((char)e).ToString())
                    .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                    .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                    .OrderBy(e => Guid.NewGuid())
                    .Take(32)
                    .ToList().ForEach(e => builder.Append(e));

            string id = builder.ToString();

            return id;
        }
    }
}