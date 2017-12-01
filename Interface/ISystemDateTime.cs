using System;

namespace HelloAngular.Interface
{
    /// <summary>
    /// ISystemDateTime
    /// </summary>
    public interface ISystemDateTime
    {
        /// <summary>
        /// Now
        /// </summary>
        /// <returns></returns>
        DateTime Now { get; }
    }
}
