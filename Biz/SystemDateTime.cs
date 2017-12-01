using System;
using HelloAngular.Interface;

namespace HelloAngular.Biz
{
    /// <summary>
    ///
    ///
    /// </summary>
    public class SystemDateTime : ISystemDateTime
    {
        /// <summary>
        /// Now
        /// </summary>
        /// <returns></returns>
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}
