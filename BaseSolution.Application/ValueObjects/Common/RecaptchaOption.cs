using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.ValueObjects.Common
{
    public class RecaptchaOption
    {
        public string SiteKey { get; set; }
        public string SecretKey { get; set; }
        public string Url { get; set; }
    }
}
