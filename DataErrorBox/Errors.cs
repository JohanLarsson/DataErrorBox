using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DataErrorBox
{
    public class Errors
    {
        private readonly Dictionary<string, string> _errors = new Dictionary<string, string>();

        public void Update(string error, [CallerMemberName] string caller = null)
        {
            _errors[caller] = error;
        }

        public void Clear([CallerMemberName] string caller = null)
        {
            _errors[caller] = string.Empty;
        }

        public string Get(string member)
        {
            string error;
            if (_errors.TryGetValue(member, out error))
            {
                return error;
            }
            return string.Empty;
        }
    }
}