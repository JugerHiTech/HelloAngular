namespace HelloAngular.Models
{
    /// <summary>
    /// 待辦事項
    /// </summary>
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
