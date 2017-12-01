using System.ComponentModel.DataAnnotations;

namespace HelloAngular.Models
{
    /// <summary>
    /// 待辦事項 TodoItem
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        public long Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        /// <returns></returns>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// IsComplete
        /// </summary>
        /// <returns></returns>
        public bool IsComplete { get; set; }
    }
}
